using AutoMapper;
using JobApplicantsSystem.Dtos;
using JobsSystem.Core.Interfaces;
using JobsSystem.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicantsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ApplicantsController(IUnitOfWork  unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Applicants.GetAllAsync().Result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            return Ok(_unitOfWork.Applicants.GetByIdAsync(Id).Result);
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string Name)
        {
            return Ok(_unitOfWork.Applicants.FindAsync(b => b.Name .Contains(Name)).Result);
        }

        [HttpPost("Add")]
        public IActionResult Add(ApplicantDto applicant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
                _unitOfWork.Applicants.AddAsync(_mapper.Map<Applicant>(applicant));
                _unitOfWork.SaveAllChanges();
            
            return Ok();
        }

        [HttpPost("ApplyForJob")]
        public IActionResult ApplyForJob(JobApplicantDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.Applicants.Apply(_mapper.Map<JobApplicant>(model));
            _unitOfWork.SaveAllChanges();

            return Ok();
        }
    }
}
