using BarinakAPI.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Infrastructure.Services
{
    public class MailService :IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string[] to, string subject, string body, bool isBodyHtml = true)
        {
           await SendMailAsync(to, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml; 
               mail.To.Add(tos); 
            mail.Subject=subject;
            mail.Body=body;
            mail.From = new(_configuration["Mail:Username"],"NG E-barınak", System.Text.Encoding.UTF8);
             
            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];
            await smtp.SendMailAsync(mail); 
        }



        public async Task SendPasswordResetMailAsyn(string to,string userId,string resetToken)
        {
            StringBuilder mail = new StringBuilder();
            mail.AppendLine("Merhaba<br> Şifre yenilemek için size gönderdiğimiz linke tıklayabilirsiniz.<br><a target=\"_blank\"href=\".../userId/resetToken");
            mail.AppendLine(_configuration["AngularClientUrl"]);
            mail.AppendLine(_configuration["/update-Password"]);

            mail.AppendLine(userId);
            mail.AppendLine("/");
            mail.AppendLine(resetToken);
            mail.AppendLine("\">yeni şifre talebi için tıklayınız </a><br>");
            
            await SendMailAsync (to ,"Şifre Yenileme Talebi",mail.ToString());
        }
    }
}
