using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        public async Task<TokenResponseModel> GetTokenAsync(TokenRequestModel model)
        {
            if (model == null)
            {
                return null;
            }
            var responseModel = new TokenResponseModel();
            var currentUser = await _userManager.FindByEmailAsync(model.Email);

            if (currentUser == null)
            {
                responseModel.Error("User does not exist");
                return responseModel;
            }

            try
            {
                if (await _userManager.CheckPasswordAsync(currentUser, model.Password))
                {
                    responseModel.Authenticated(
                        new JwtSecurityTokenHandler().WriteToken(await CreateJwtToken(currentUser))
                    );

                    return responseModel;
                }
            }
            catch (Exception e)
            {
                responseModel.Error($"Something went wrong: {e.Message}");
                return responseModel;
            }

            responseModel.Error("Incorrect password");
            return responseModel;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(IdentityUser currentUser)
        {
            var userClaims = await _userManager.GetClaimsAsync(currentUser);
            var roles = await _userManager.GetRolesAsync(currentUser);

            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(item: new Claim("roles", role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, currentUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, currentUser.Email),
                new Claim("uid", currentUser.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            return new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: System.DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCred
            );
        }

        public async Task<bool> CreateStudent(RegisterStudentModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = true
            };

            var createdUser = await _userManager.FindByEmailAsync(user.Email);

            if (createdUser == null)
            {
                await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, Roles.Student.ToString());

                return true;
            }

            return false;
        }
    }
}