using JobsSystem.Core.Interfaces;
using JobsSystem.Core.Models;
using JobSystem.EF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSystem.EF.Repositories
{

    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMailingService _mailing;

        public JobRepository(ApplicationDBContext context, IMailingService mailing) : base(context)
        {
            _context = context;
            _mailing = mailing;
        }
        public void Notify(int JobId,string JobStatus)
        {
            var Applicants = _context.JobApplicants.Where(m => m.JobId == JobId).Include(m=>m.Applicant);
            string messageBody = $"The Job Status become {JobStatus}";
            string Subject = "Hello ";
            foreach (var m in Applicants)
            {
                _mailing.SendingEmailAsync(m.Applicant.EMailAdress, Subject + m.Applicant.Name, messageBody);
            }

           
        }

       
    }
}
