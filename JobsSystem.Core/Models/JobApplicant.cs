using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsSystem.Core.Models
{
    public class JobApplicant
    {
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
