using JobsSystem.Core.Interfaces;
using JobsSystem.Core.Models;
using JobSystem.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSystem.EF.Repositories
{
  public  class ApplicantsRepository:BaseRepository<Applicant> ,IApplicantRepository
{
        private readonly ApplicationDBContext _context;

        public ApplicantsRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public JobApplicant Apply(JobApplicant applicant)
        {
            _context.JobApplicants.Add(applicant);
            return applicant;

        }
    }
}
