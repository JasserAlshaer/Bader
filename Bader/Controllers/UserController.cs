using Bader.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bader.Core.Data;
using Bader.Core.DTO;
using System.Collections.Generic;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Bader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserGate _gate;
       public UserController(IUserGate gate)
        {
            _gate = gate;
        }


        enum RoleType
        {
            NoOne, Admin, Employee
        }


        public int DecodeToken(String tokenString)
        {

            String toke = "Bearer " + tokenString;

            var jwtEncodedString = toke.Substring(7);

            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);

            int roleType = Int32.Parse((token.Claims.First(c => c.Type == "role").Value.ToString()));
            if (roleType == 1 && token.ValidTo >= DateTime.Now)
            {

                return (int)RoleType.Admin;
            }
            else if (roleType == 2 && token.ValidTo >= DateTime.Now)
            {

                return (int)RoleType.Employee;
            }
            else
            {


                return (int)RoleType.NoOne;
            }
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult FetchDonationCampagin([FromBody]DonationCampaingeRequestDTO fillter, [FromHeader] String token)
        {
            int result = DecodeToken(token);

            if (result == 1)
            {

                return Ok(_gate.FetchDonationCampagin(fillter));
            }
            else if (result == 2)
            {
                return Unauthorized();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult FetchInitiative([FromBody] InitiativeDTO fillter, [FromHeader] String token)
        {
            int result = DecodeToken(token);

            if (result == 1)
            {

                return Ok(_gate.FetchInitiative(fillter));
            }
            else if (result == 2)
            {
                return Unauthorized();
            }
            else
            {
                return BadRequest();
            }
            
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllNumericInfo([FromHeader] String token)
        {
            int result = DecodeToken(token);

            if (result == 1)
            {

                return Ok(_gate.GetAllNumericInfo());
            }
            else if (result == 2)
            {
                return Unauthorized();
            }
            else
            {
                return BadRequest();
            }
         
        }


    }
}
