using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TamoodlApi.Authentication;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Accounts
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;

        public UserService(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }
        public async Task<string> GetTokenAsync(TokenRequestModel model)
        {
            if(model == null)
            {
                return null;
            }

            var currentUser = await _userManager.FindByEmailAsync(model.Email);

            if(currentUser == null)
            {
                return "No such user";
            }

            try
            {
                if(await _userManager.CheckPasswordAsync(currentUser, model.Password))
                {
                    return new JwtSecurityTokenHandler().WriteToken(await CreateJwtToken(currentUser));
                }                   
            }
            catch(Exception e)
            {
                return $"Something went wrong: {e.Message}";
            }

            return "Incorrect password";
        }

        private async Task<JwtSecurityToken> CreateJwtToken(IdentityUser currentUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, currentUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, currentUser.Email),
                new Claim("uid", currentUser.Id)
            };

            return new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: System.DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCred
            );
        }
    }
}