using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Gate;
using Bader.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bader.Infra.Gate
{
    public class AuthorizationGate : IAuthorizationGate
    {

        private readonly IAuthorizationService _authorizationService;

        public AuthorizationGate(IAuthorizationService service)
        {
            _authorizationService = service;
        }

        public string LoginCredinital(LoginFillterDTO fillter)
        {
            return _authorizationService.LoginCredinital(fillter);
        }

        public bool LogoutFromSystem(string email)
        {
            return _authorizationService.LogoutFromSystem(email);
        }

        public Task<bool> RegisterNewCharity(CharityRegisterDTO charity, string email, string password)
        {
            return _authorizationService.RegisterNewCharity(charity,email,password);
        }

        public bool ResponseToCharityAddingRequest(int response, int charityId)
        {
            return _authorizationService.ResponseToCharityAddingRequest(response, charityId);
        }

        public bool ResetPassword(ResetDTO dto)
        {
            return _authorizationService.ResetPassword(dto);
        }
    }
}
