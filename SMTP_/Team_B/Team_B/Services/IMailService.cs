using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team_B.DbModels;

namespace Team_B.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
