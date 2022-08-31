using clotheshop.Context;
using clotheshop.Models;
using clotheshop.Models.Email;
using clotheshop.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder)
    .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options => {
    var supportedCultures = new[] { "en", "ru", "be-by", "uk-ua", "be", "la" };
    options.SetDefaultCulture(supportedCultures[3])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
     app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

var supportedCultures = new[] { "en", "ru", "be-by", "uk-ua", "be", "la" };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[3])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
