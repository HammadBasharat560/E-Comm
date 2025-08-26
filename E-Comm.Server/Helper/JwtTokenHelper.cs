using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using E_Comm.Server.ModelDto;
using E_Comm.Server.Entities;

namespace E_Comm.Server.Helper
{
    public class JwtTokenHelper
    {
        private readonly IConfiguration _config;

        public JwtTokenHelper(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(User loginRequest)
        {
            var claims = new[]
            {
                new Claim("UserId", loginRequest.Id.ToString()),
                new Claim("Email", loginRequest.Email ?? string.Empty),
                new Claim("UserName", loginRequest.Name ?? string.Empty),
                new Claim("Role", loginRequest.Role.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

            public string GenerateOTP(int length = 6)
            {
                var random = new Random();
                var otp = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    otp.Append(random.Next(0, 10));
                }
                return otp.ToString();
            }
    }
}
