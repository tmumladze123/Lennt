using Lennt.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace Lennt.Services.Service
{
    public class JwtPasswordInterfaceService : IJwtPasswordInterface
    {
        #region Service
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtPasswordInterfaceService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        #endregion

        public string GenerateJwtToken(string username, long UserId)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim("Id", UserId.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtExpireMinutes"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public int GetUserId()
        {
            string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (accessToken == null) throw new Exception("Unauthorized User");

            var handler = new JwtSecurityTokenHandler();
            var testToken = handler.ReadJwtToken(accessToken[7..]);
            var claimId = testToken.Claims.FirstOrDefault(claim => claim.Type == "Id");

            if (claimId == null) throw new Exception("Unauthorized User");

            int id = Convert.ToInt32(claimId.Value);

            return id;
        }
        public string GetRole()
        {
            string accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (accessToken == null) throw new Exception("Unauthorized User");

            var handler = new JwtSecurityTokenHandler();
            var testToken = handler.ReadJwtToken(accessToken[7..]);
            var claim = testToken.Claims.FirstOrDefault(claim => claim.Type == "Role");

            if (claim == null) throw new Exception("Unauthorized User");



            return claim.Value;
        }

        public string HashPassword(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Salt"));

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public bool ValidatePassword(string password, string hashed)
        {
            var isValid = HashPassword(password) == hashed;
            return isValid;
        }
    }
}
