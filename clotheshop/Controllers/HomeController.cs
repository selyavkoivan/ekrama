using clotheshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using clotheshop.Context;
using clotheshop.Controllers.Services.EmailServices;
using clotheshop.Models.Email;
using clotheshop.Models.User;
using clotheshop.Models.User.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace clotheshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly EmailConfiguration _emailConfiguration;

        public HomeController(ApplicationContext context, UserManager<User> userManager,
            SignInManager<User> signInManager, IStringLocalizer<HomeController> localizer,
            EmailConfiguration emailConfiguration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _localizer = localizer;
            _emailConfiguration = emailConfiguration;
        }

        [HttpPost]
        public IActionResult SetAppLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions {Expires = DateTimeOffset.UtcNow.AddYears(1)}
            );

            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserDto userDto)
        {
            try
            {
                var user = new User(userDto);
                var answer = await _userManager.CreateAsync(user, userDto.password);
                if (answer.Succeeded)
                {
                    SendEmail(user);
                    return View("SignIn");
                }

                MakeMistakeText(answer);
            }
            catch (ArgumentNullException)
            {
                ModelState.AddModelError("Password", "Please repeat the password");
            }

            return View("index");
        }

        public async void SendEmail(User user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Home",
                new {userId = user.Id, code},
                protocol: HttpContext.Request.Scheme);
            var text = await MakeConfirmEmailBody(callbackUrl);

            var message = new Message(new[] {user.Email}, _localizer["Birthday"], text);
            new EmailSenderImpl(_emailConfiguration).SendEmail(message);
        }

        private async Task<string> MakeConfirmEmailBody(string callbackUrl)
        {
            var actionContext = ControllerContext as ActionContext;

            var serviceProvider = ControllerContext.HttpContext.RequestServices;
            var razorViewEngine = serviceProvider.GetService(typeof(IRazorViewEngine)) as IRazorViewEngine;
            var tempDataProvider = serviceProvider.GetService(typeof(ITempDataProvider)) as ITempDataProvider;

            await using var sw = new StringWriter();

            var viewResult = razorViewEngine?.FindView(actionContext, 
                "../EmailTemplate/ConfirmEmailTemplate", false);
            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(),
                        new ModelStateDictionary()) {Model = callbackUrl};

            var viewContext = new ViewContext(actionContext, viewResult.View, viewDictionary,
                new TempDataDictionary(actionContext.HttpContext, tempDataProvider), sw, new HtmlHelperOptions());

            await viewResult.View.RenderAsync(viewContext);
            return sw.ToString();
            
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.ConfirmEmailAsync(user, code);
                if (result.Succeeded) return RedirectToAction("SignIn", "Home");
                return View("Error");
            }
            catch (ArgumentNullException)
            {
                return View("Error");
            }
        }

        private void MakeMistakeText(IdentityResult answer)
        {
            if (answer.Errors.Any(e => e.Code.ToLower().Contains("username")))
            {
                ModelState.AddModelError("Username", _localizer["UsernameError"]);
            }

            if (answer.Errors.Any(e => e.Code.ToLower().Contains("email")))
            {
                ModelState.AddModelError("Email", "duplicate email");
            }

            if (answer.Errors.Any(e => e.Code.ToLower().Contains("password")))
            {
                ModelState.AddModelError("Password", "Incorrect password");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}