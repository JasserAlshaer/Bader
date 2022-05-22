using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Gate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoraztionController : ControllerBase
    {
        private readonly IAuthorizationGate _Gate;


        public AuthoraztionController(IAuthorizationGate gate)
        {
            this._Gate = gate;
        }
        [HttpPost]
        public bool LogoutFromSystem(String email)
        {
            return _Gate.LogoutFromSystem(email);
        }
        [HttpPost]
        public String LoginCredinital(LoginFillterDTO fillter)
        {
            return _Gate.LoginCredinital(fillter);
        }

        [HttpPost]
        public bool RegisterNewCharity(CharityRegisterDTO charity)
            
        {
            Charity charity1 = new Charity();
            charity1.Name = charity.Name;
            charity1.IsActive = charity.IsActive;
            charity1.Phone = charity1.Phone;    

            return _Gate.RegisterNewCharity(charity1, charity.email, charity.password);
        }


        [HttpPost]
        public bool ResponseToCharityAddingRequest(int response, int charityId)
        {
            return _Gate.ResponseToCharityAddingRequest(response, charityId);
        }
        
    }
}
