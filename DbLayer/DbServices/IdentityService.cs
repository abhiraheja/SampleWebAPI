using DbLayer.Framework;
using DbLayer.Framework.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Authentication;
using Models.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.DbServices
{
    public class IdentityService : IIdentityService
    {
        IDbEntity _db;
        private readonly JwtSettings _jwtSettings;
        public IdentityService(IDbEntity db, JwtSettings jwtSettings)
        {
            _db = db;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthenticationResult> RegisterAsync(string Username, string Password)
        {
            var existsUser = await _db.sA_Logins.Where(i => i.Username == Username).ToListAsync();
            if (existsUser.Count > 0)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Username is already exists" }
                };
            }
            var newUser = new SA_Login
            {
                Username = Username,
                Password = Password,
                CreatedAt = DateTime.Now,
                Is_deleted = false,
                UpdatedAt = DateTime.Now
            };
            var result = await _db.SaveAsync(newUser);
            if (result < 1)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User not registered successfully." }
                };
            }
            return createToken(newUser);

        }

        private AuthenticationResult createToken(SA_Login newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Username", newUser.Username),
                    new Claim("Id", newUser.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
