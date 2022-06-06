using AutoMapper;
using JobApplicantsSystem.Dtos;
using JobsSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsSystem.Core.Dtos
{
  public  class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<JobDto, Job>().ReverseMap();
            CreateMap<ApplicantDto, Applicant>().ReverseMap();
            CreateMap<JobApplicantDto, JobApplicant>().ReverseMap();
        }
    }
}
