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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IApplicantRepository Applicants { get; private set; }

        public IJobRepository Jobs { get; private set; }

       

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Applicants = new ApplicantsRepository(_context);
            Jobs = new JobRepository(_context);
        }

     
        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveAllChanges()
        {
            return _context.SaveChanges();
        }
    }
}
