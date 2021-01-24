using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness_layer.Models.CreateModels;
using Bussiness_layer.Models.LoginModels;
using Bussiness_layer.RepServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VirtualTennisApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthModel model)
        {
            var token = await _authService.Authenticate(model);
            if (token == null)
            {
                return BadRequest("Invalid email or password");
            }

            return Ok(token);
        }

    }
}