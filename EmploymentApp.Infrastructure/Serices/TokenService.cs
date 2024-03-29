﻿using EmploymentApp.Core.CustomEntities;
using EmploymentApp.Core.Entities;
using EmploymentApp.Core.Enums;
using EmploymentApp.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
namespace EmploymentApp.Infrastructure.Serices
{
    /// <summary>
    /// Has methods to generate token with shema defined
    /// </summary>
    public class TokenService: ITokenService
    {
        
        private readonly AuthenticationOptions _authenticationOptions;
        public TokenService(IOptions<AuthenticationOptions> options)
        {
            _authenticationOptions = options.Value;
        }
        public Token GenerateToken(User user)
        {
            //header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationOptions.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(nameof(PublicClaims.UserId), user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.UserLogin.ElementAt(0).Email),
                new Claim(ClaimTypes.Role, user.UserLogin.ElementAt(0).Role.Name),
                new Claim(ClaimTypes.DateOfBirth, user.Bithdate.ToShortDateString()),
            };

            //payload
            var payload = new JwtPayload(
                _authenticationOptions.Issuer,
                _authenticationOptions.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(60000)
                );

            var token = new JwtSecurityToken(header, payload);
            string jwtString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token
            {
                Data = jwtString,
                DateCreated = DateTime.UtcNow,
                DateToExpire = DateTime.UtcNow.AddMinutes(60000)
            };
        }
    }
}
