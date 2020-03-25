using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Bon_Voyage.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("bonvoyagevirus@gmail.com");
            mail.To.Add(email);
            mail.Subject = "Зміна паролю";
            mail.IsBodyHtml = true;
            mail.Body = message;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("bonvoyagevirus@gmail.com", "bon123456-"),
                EnableSsl = true
            };
            client.Send(mail);
        }
    }
}
