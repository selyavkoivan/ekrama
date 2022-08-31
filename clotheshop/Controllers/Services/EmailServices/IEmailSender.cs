using clotheshop.Models.Email;

namespace clotheshop.Controllers.Services.EmailServices;

public interface EmailSender
{
    void SendEmail(Message message);
}