using IServicio.Email;

namespace IServicio.Email
{
    public interface IEmailSender
    {
        void SendEmail(Message email);
    }
}
