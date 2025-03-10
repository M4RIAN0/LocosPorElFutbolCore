using IServicio.Email;

namespace IServicio.Email
{
    public interface IEmailSender
    {
        bool SendEmail(Message email);
    }
}
