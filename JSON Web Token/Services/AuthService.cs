using JSON_Web_Token.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JSON_Web_Token.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration config;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }

        public async Task<bool> Register(RegisterVM model)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            return result.Succeeded;
        }

        public async Task<bool> Login(LoginVM model)
        {
            var user = await userManager.FindByEmailAsync(model.UserName);
            if (user == null)
            {
                return false;
            }
            return await userManager.CheckPasswordAsync(user, model.Password);
        }

        public string GenerateTokenString(LoginVM model)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,model.UserName),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Jwt:Key").Value));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                //issuer: config.GetSection("Jwt:Issuer").Value,
                //audience: config.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signingCredentials
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}

