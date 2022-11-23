﻿using Market.Domain.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Market.Application.Security
{
    public class Auth : IAuth
    {
        private readonly IConfiguration _configuration;

        public Auth(IConfiguration configuration) => _configuration = configuration;

        public string GetRefreshToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            
            byte[] key = Guid.NewGuid().ToByteArray();
            
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            return token;
        }

        public string CreateToken(
            string email, string userId, UserRole userRole)
        {
            var claims = Claims(email: email, userRole: userRole,
                userId: userId);

            var key = GetSymmetricSecurityKey(_configuration["token:key"]);

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    audience: _configuration["token:audience"],
                    issuer: _configuration["token:issuer"],
                    notBefore: now,
                    claims: claims,
                    expires: now.Add(TimeSpan.FromMinutes(int.Parse(_configuration["token:accessTokenExpiryMinutes"]))),
                    signingCredentials: signIn);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }

        public Claim[] Claims(string email, string userId, UserRole userRole)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["token:subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole.ToString()),
                new Claim("user_id", userId),
                new Claim("email", email)
            };
        }
    }
}
