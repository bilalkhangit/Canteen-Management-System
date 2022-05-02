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
        private string _userName;
        private string _password;   
        public SMTPEmailSender(string userName, string passWord)
        {
            _userName = userName;
            _password = passWord;
        }
        public async Task SendEmailAsync(string to, string subject, string message)
        {
            //string to = to; //To address    
            string from = _userName; //From address    
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
                    System.Net.NetworkCredential(_userName, _password);
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
