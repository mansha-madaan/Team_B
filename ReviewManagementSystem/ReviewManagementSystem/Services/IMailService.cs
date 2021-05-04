using ReviewManagementSystem.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ReviewManagementSystem.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
