namespace clotheshop.Models.User.UserDto;

public class UserDto
{
    public string email { get; set; }
    public string username { get; set; }


    private string passwordField;
    public string password
    {
        get => passwordField.Equals(repeatedPassword) ? passwordField : null;
        set => passwordField = value;
    }
    
    public string repeatedPassword { get; set; }
}