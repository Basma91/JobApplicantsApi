using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsSystem.Core.Interfaces
{
     public  interface IMailingService
         {
        Task SendingEmailAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null);
         }
}
