using JobsSystem.Core.Interfaces;
using JobsSystem.Core.Models.Registeration;
using Microsoft.AspNetCore.Authorization;
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

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Result = await _service.RegisterAsync(model);

            if (!Result.IsAuthenticated)
                return BadRequest(Result.Message);

            return Ok(Result);

           // return Ok(new { Token = Result.Token, Expire = Result.ExpireOn });
        }


        [HttpPost("Token")]
        public async Task<IActionResult> GetToken(TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Result = await _service.GetTokenAsync(model);

            if (!Result.IsAuthenticated)
                return BadRequest(Result.Message);

            return Ok(Result);

        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Result = await _service.AddRoleAsync(model);

            if (!string.IsNullOrEmpty( Result))
                return BadRequest(Result);

            return Ok(model);

        }
    }
}
