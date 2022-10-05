using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.UserAccountCommand
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, string>
    {
        private readonly UserManager<Person> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IConfiguration _configuration;

        public UserLoginCommandHandler(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _usermanager = userManager;
            _rolemanager = roleManager;
            _configuration = configuration;
        }
        public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            Person person = await _usermanager.FindByNameAsync(request.PersonalNumber);
            if (person == null) return null;

            bool result = await _usermanager.CheckPasswordAsync(person, request.Password);
            if (!result) return null;

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, person.Id),
                new Claim(ClaimTypes.Name, person.Name),
                new Claim(ClaimTypes.Surname, person.Surname),
                new Claim(ClaimTypes.UserData, person.UserName)
            };

            IList<string> roles = await _usermanager.GetRolesAsync(person);
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            string keystr = _configuration["Jwt:Key"];

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keystr));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                signingCredentials: credentials,
                expires: DateTime.Now.AddHours(1),
                claims: claims
                );
            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenStr;
        }
    }
}