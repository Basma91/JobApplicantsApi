using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicantsSystem.Dtos
{
    public class JobApplicantDto
    {
        [Required]
        public int JobId { get; set; }
        [Required]
        public int ApplicantId { get; set; }
    }
}
