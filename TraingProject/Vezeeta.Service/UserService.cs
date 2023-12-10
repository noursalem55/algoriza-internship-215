using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vezeeta.Core.Dtos;
using Vezeeta.Core.Entities;
using Vezeeta.Repo.GenericRepository;
using Vezeeta.Service.Interfaces;

namespace Vezeeta.Service
{
    public class UserService:IUserService
    {
        private readonly IBaseRepository<ApplicationUser> _User;

        public UserService(IBaseRepository<ApplicationUser> user)
        {
            _User = user;
        }
        public string Login(LoginDTO model)
        {
            string token = "";
            var user = Authenticate(model.Email, model.Password);
            if (user == null)
            {
                return token;
            }
            // If authentication is successful, generate JWT with user's information
             token = GenerateJwtToken(user.ID);

            return token;
        }

        public bool Register(RegisterDTO model)
        {
            throw new NotImplementedException();
        }
        #region Helper
      
        private ApplicationUser Authenticate(string Email, string password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))
                return null;

            var user = _User.GetQueryAll().SingleOrDefault(x => x.Email == Email && x.Password==password);
            // check if Email exists
            if (user == null)
                return null;
           
            // authentication successful
            return user;
        }
        private string GenerateJwtToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("6e3c657f454d6ff5ee6606d8b2bf52ce"); // Same key as in the configuration
                                                                                  // Ensure the key size is at least 128 bits (16 bytes)
            if (key.Length < 16)
            {
                // Pad the key with zeros or handle it as needed
                Array.Resize(ref key, 16);
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(ClaimTypes.Name, userId.ToString()), // Include user ID in the claim
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
