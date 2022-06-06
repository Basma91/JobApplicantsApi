using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsSystem.Core.Models
{
   public class Job
    {
        //public Job()
        //{
        //    this.Applicants = new HashSet<Applicant>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  JobId { get; set; }
        [Required]

        [StringLength(50)]
        
        public string Name { get; set; }

        [Required]

        [StringLength(200)]

        public string Description { get; set; }

        public string JobStatus { get; set; }

        public ICollection<JobApplicant> JobApplicants { get; set; }
    }
}
