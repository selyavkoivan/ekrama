using Microsoft.AspNetCore.Identity;

namespace clotheshop.Models.User;

    public class User: IdentityUser
    {
        public User(UserDto.UserDto userDto)
        {
            UserName = userDto.username;
            Email = userDto.email;
        }

        public User() : base()
        {
        }

        public string? Surname { get; set; }
        public string? Name { get; set; }
        public DateTime Birthday { get; set; }

    }

