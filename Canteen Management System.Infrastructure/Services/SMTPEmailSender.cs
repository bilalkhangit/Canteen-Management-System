using Canteen_Management_System.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System.Infrastructure.Services
{
    public class SMTPEmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string to, string subject, string message)
        {
            //string to = to; //To address    
            string from = "BilalOpenSourceWork@gmail.com"; //From address    
            MailMessage mailMessage = new MailMessage(from, to);

            string mailbody = message;
            mailMessage.Subject = subject;
            mailMessage.Body = mailbody;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587)) //Gmail smtp 
                {
                    System.Net.NetworkCredential basicCredential1 = new
                    System.Net.NetworkCredential("BilalOpenSourceWork@gmail.com", "bilalopensource#1234");
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential1;
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
