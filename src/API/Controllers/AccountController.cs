using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Middleware;
using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /**
            - Token is generated using login credentials.
        **/
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = _userService.Authenticate(model);

            if (response == null)
            {
                return Unauthorized();
            }

            //return Ok(response);
            return new CreatedResult("",new AuthenticateResponse {id_token = response.id_token});
        }
    }
}