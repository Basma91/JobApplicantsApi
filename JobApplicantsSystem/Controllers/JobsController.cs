using AutoMapper;
using JobsSystem.Core.Dtos;
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
    public enum JobStatus { Opened, FILLED , REMOVED  }

    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Jobs.GetAllAsync().Result);
        }

        [HttpPost("Add")]
          public IActionResult Add(JobDto jobDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Job Job = _mapper.Map<Job>(jobDto);
            Job.JobStatus = JobStatus.Opened.ToString();


            _unitOfWork.Jobs.AddAsync(Job);
            _unitOfWork.SaveAllChanges();

            return Ok();




        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id ,JobDto dto)
        {
            var Job = a  wait _unitOfWork.Jobs.GetByIdAsync(id);

            if (Job == null)
                return NotFound($"No Job was found with ID {id}");

            _unitOfWork.Jobs.Update(_mapper.Map<Job>(dto));
            _unitOfWork.SaveAllChanges();
            _unitOfWork.Jobs.Notify(Job.JobId, Job.JobStatus);
            return Ok(Job);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var Job = await _unitOfWork.Jobs.GetByIdAsync(id);

            if (Job == null)
                return NotFound($"No Job was found with ID {id}");

            _unitOfWork.Jobs.Delete(Job);
            _unitOfWork.SaveAllChanges();

            return Ok(Job);
        }
    }
}
