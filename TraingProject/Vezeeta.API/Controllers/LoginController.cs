using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Drawing.Printing;
using Vezeeta.Core.Dtos;
using Vezeeta.Core.Entities;
using Vezeeta.Repo.GenericRepository;
using Vezeeta.Service.Interfaces;

namespace Vezeeta.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller 
    {
        private readonly IUserService _User;
        
        public LoginController(IUserService user) {
            _User = user;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            try
            {
                string token = _User.Login(model);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized();
                }
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


    }
}
