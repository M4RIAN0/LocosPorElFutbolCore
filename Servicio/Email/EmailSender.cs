using IServicio.Email;
using IServicio.Mail;
using System;
using System.Net;
using System.Net.Mail;

namespace Servicio.Email
{
    public class EmailSender: IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        private MailMessage CreateEmailMessage(Message message)
        {
            MailMessage emailMessage = new MailMessage(_emailConfig.From, message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body =  message.Content;

            return emailMessage;

        }

        private void Send(MailMessage mailMessage)
        {
            using var client = new SmtpClient(_emailConfig.SmtpServer, 587);
            {
                try
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;

                    client.Send(mailMessage);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    client.Dispose();
                }
            }
        }
    }
}
