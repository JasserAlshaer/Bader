using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Gate;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        [Route("[action]")]
        public bool LogoutFromSystem(String email)
        {
            return _Gate.LogoutFromSystem(email);
        }
        [HttpPost]
        [Route("[action]")]
        public String LoginCredinital(LoginFillterDTO fillter)
        {
            return _Gate.LoginCredinital(fillter);
        }

        [HttpPost]
        [Route("[action]")]
        public Task<bool> RegisterNewCharity(CharityRegisterDTO charity)
            
        {
            
            return _Gate.RegisterNewCharity(charity, charity.email, charity.password);
        }


        [HttpGet]
        [Route("[action]")]
        public bool ResponseToCharityAddingRequest([FromQuery]int response,[FromQuery] int charityId)
        {
            return _Gate.ResponseToCharityAddingRequest(response, charityId);
        }

        [HttpPost]
        [Route("[action]")]
        public bool ResetPassword(ResetDTO dto)
        {
            return _Gate.ResetPassword(dto);
        }

    }
}
