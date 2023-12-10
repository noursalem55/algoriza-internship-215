using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vezeeta.Core.Dtos;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Helpers;

namespace Vezeeta.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtOptions _jwt;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
           IOptions<JwtOptions> jwt
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwt = jwt.Value;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    //UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password= model.Password,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Patient");
                    return Ok("Registration successful");
                }
                return BadRequest(result.Errors);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var token = await GenerateJwtTokenAsync(user);

                    return Ok(new { token });
                }

                return Unauthorized("Invalid login attempt.");
            }

            return BadRequest(ModelState);
        }

        //[HttpPost("logout")]
        //[Authorize]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return Ok("Logout successful");
        //}

        //[HttpPost("register/Doctor")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> RegisterDoctor(GetAllDoctorDTO model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser
        //        {
        //            //UserName = model.UserName,
        //            Email = model.Email,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            //speciality= model.Speciality
        //        };

        //        var result = await _userManager.CreateAsync(user, model.Password);

        //        if (result.Succeeded)
        //        {
        //            await _userManager.AddToRoleAsync(user, "Doctor");
        //            return Ok("Doctor Registration was successful");
        //        }
        //        return BadRequest(result.Errors);
        //    }
        //    return BadRequest(ModelState);
        //}

        //[HttpPut("edit-profile")]
        //[Authorize]
        //public async Task<IActionResult> EditProfile(EditProfileDTO model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var user = await _userManager.FindByIdAsync(userId);

        //        if (user != null)
        //        {
        //            user.Email = model.Email;
        //            user.FirstName = model.FirstName;
        //            user.LastName = model.LastName;

        //            if (!string.IsNullOrEmpty(model.NewPassword))
        //            {
        //                // Change the password if a new password is provided
        //                var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

        //                if (!changePasswordResult.Succeeded)
        //                {
        //                    return BadRequest(changePasswordResult.Errors);
        //                }
        //            }

        //            var result = await _userManager.UpdateAsync(user);

        //            if (result.Succeeded)
        //            {
        //                return Ok("Profile updated successfully");
        //            }

        //            return BadRequest(result.Errors);
        //        }

        //        return NotFound("User not found");
        //    }

        //    return BadRequest(ModelState);
        //}

        //private async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
        //{
        //    var claims = new List<Claim>
        //    {
        //    new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    new Claim(ClaimTypes.NameIdentifier, user.Id)
        //    };
        //    var roles = await _userManager.GetRolesAsync(user);
        //    foreach (var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
        //    }

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var expires = DateTime.Now.AddMinutes(30);

        //    var token = new JwtSecurityToken(
        //        config["Jwt:Issuer"],
        //        config["Jwt:Audience"],
        //        claims,
        //        expires: expires,
        //        signingCredentials: creds
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        private async Task<JwtSecurityToken> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                        //new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        //new Claim("uid", user.Id.ToString())
                    }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

    }
}
