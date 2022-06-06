using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicantsSystem.Dtos
{
    public class ApplicantDto
    {
        public int ID { get; set; }
        [Required]

        [MinLength(5, ErrorMessage = "The name  must be at least 5 characters ")]
        public string Name { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "The family name  must be at least 5 characters ")]
        public string FamilyName { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "The address  must be at least 10 characters ")]
        public string Address { get; set; }

        [Required]
        public string CountryOfOrigin { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EMailAdress { get; set; }
        [Range(20, 60, ErrorMessage = "The age  must be between 20 and 60 ")]
        public int Age { get; set; }
    }
}
