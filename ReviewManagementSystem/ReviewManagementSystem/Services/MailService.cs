
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using ReviewManagementSystem.DbModels;
using ReviewManagementSystem.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewManagementSystem.Services
{
    public class MailService:IMailService
    {
        private EmployeeDBContext _context;
       

       
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings, EmployeeDBContext context)
        {
            _context = context;
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            //var columns = _context.EmpLogin.Select(n => new {
            //    n.EmpEmailId
            //    });

            //foreach(var emailid in columns)
            //{
            //    mailRequest.ToEmail.Add(emailid.ToString());
            //}

            //foreach (var toEmail in mailRequest.ToEmail)
            //{


                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                //email.To.Add(MailboxAddress.Parse(toEmail));
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                //foreach (var toEmail in mailRequest.ToEmail)
                //{
                //    email.To.Add(toEmail);
                //}
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                if (mailRequest.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in mailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            //}
        }
    }
}
