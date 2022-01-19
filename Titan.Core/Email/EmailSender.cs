using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Titan.Core.Email
{
    public class EmailSender : IEmailSender
    {
        public void Send(string emailDestino)
        {
            var fromAddress = new MailAddress("2damproyectocutre@gmail.com", "Equipo de desarrollo de ratatata");
            var toAddress = new MailAddress(emailDestino, "To Name");
            const string fromPassword = "RatitaInsensill@";
            const string subject = "Welcome to Miami!";
            const string body = "Bienvenido!!!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
