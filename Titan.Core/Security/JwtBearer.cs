using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.Core.Security
{
    public class JwtBearer : IJwtBearer
    {
        public IConfiguration Configuration { get; set; }

        public JwtBearer(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public string GenerateJWTToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Id",usuario.Id.ToString()),
                new Claim("Email", usuario.Email),
                new Claim("Random", new Guid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: Configuration["Jwt:Issuer"],
                audience: Configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public int GetEmpresaIdFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token.Replace("Bearer ", string.Empty));
            var tokenS = jsonToken as JwtSecurityToken;
            var id = tokenS.Claims.FirstOrDefault(claim => claim.Type == "Id");
            return id != null ? Int32.Parse(id.Value) : 0;

        }



    }
}
