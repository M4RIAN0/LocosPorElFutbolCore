using IServicio.Email;
using IServicio.Mail;
using System;
using System.Net;
using System.Net.Mail;

namespace Servicio
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public bool SendEmail(Message message)
        {
            var emailMessage = new MailMessage(_emailConfig.FromEmail, message.To)
            {
                Subject = message.Subject,
                Body = message.Content,
                IsBodyHtml = true
            };

            return Send(emailMessage);
        }

        #region private methods
        private bool Send(MailMessage mailMessage)
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

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    client.Dispose();
                }
            }
        }
        #endregion
    }
}
