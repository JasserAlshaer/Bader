using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Repository;
using Bader.Core.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bader.Infra.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationRepository _repos;

        public AuthorizationService(IAuthorizationRepository repo)
        {
            _repos = repo;
        }


        public String LoginCredinital(LoginFillterDTO fillter)
       {
            var result = _repos.LoginCredinital(fillter);

            if (result == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes("LongSecrectStringForModulekodestart");
                var tokenDescriptior = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email,result.Email),
                        new Claim ("RoleId",result.roleID+""),
                        new Claim("ChartiyId",result.CharityID+""),
                        new Claim("AdminId",result.AdminId+"")
                    }),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                    , SecurityAlgorithms.HmacSha256Signature)


                };
                var token = tokenHandler.CreateToken(tokenDescriptior);
                return tokenHandler.WriteToken(token);
            }
        }

        public bool LogoutFromSystem(string email)
        {
          return _repos.LogoutFromSystem(email);
        }

        public bool RegisterNewCharity(Charity charity, string email, string password)
        {
            return _repos.RegisterNewCharity(charity, email, password);
        }

        public bool ResponseToCharityAddingRequest(int response, int charityId)
        {
            return _repos.ResponseToCharityAddingRequest(response, charityId);
        }

       
    }
}
