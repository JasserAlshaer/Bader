﻿using Bader.Core.Data;
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
        public bool RegisterNewCharity(CharityRegisterDTO charity)
            
        {
            Charity charity1 = new Charity();
            charity1.Name = charity.Name;
            charity1.IsActive = false;
            charity1.Phone = charity.Phone;    
            charity1.DateofEstablishment=DateTime.Now;
            charity1.Description = "New Charity Join Bader Platform";
           // charity1.ProfileImagePath = "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";

            return _Gate.RegisterNewCharity(charity1, charity.email, charity.password);
        }


        [HttpPost]
        [Route("[action]")]
        public bool ResponseToCharityAddingRequest(int response, int charityId)
        {
            return _Gate.ResponseToCharityAddingRequest(response, charityId);
        }
        
    }
}
