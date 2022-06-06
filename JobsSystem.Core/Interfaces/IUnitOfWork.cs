using JobsSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsSystem.Core.Interfaces
{
  public  interface IUnitOfWork:IDisposable
    {
        IApplicantRepository Applicants { get; }
        IJobRepository Jobs { get; }

        int SaveAllChanges();
    }
}
