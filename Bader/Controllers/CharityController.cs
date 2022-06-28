using Bader.Core.Data;
using Bader.Core.Gate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Bader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharityController : ControllerBase
    {
        private readonly ICharityGate _Gate;
        private readonly BaderContext _Context;


        public CharityController(ICharityGate gate,BaderContext context)
        {

            _Context = context;
            this._Gate = gate;
        }


        public bool DecodeToken(String tokenString)
        {

            String toke = "Bearer " + tokenString;

            var jwtEncodedString = toke.Substring(7);

            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);

            int roleId = Int32.Parse((token.Claims.First(c => c.Type == "RoleId").Value.ToString()));
            if (roleId == 2 && token.ValidTo > DateTime.UtcNow)
            {

                return true;
            }
            else
            {

                return false;
            }


        }




        [HttpPost]
        [Route("[action]")]
        public IActionResult InsertDonationCampaign([FromBody]DonationCampaign donationCampaign, [FromHeader] string token)
        {
            if (DecodeToken(token))
            {
                return Ok(_Gate.InsertDonationCampaign(donationCampaign));
            }
            else
            {
                return Unauthorized();
            }
          
        }
        [HttpPost]
        
        [Route("[action]")]
        public IActionResult InsertNewInitiative([FromBody] Initiative initiative, [FromHeader] string token)
        {
            initiative.ScheduleType = "Sunday-Friday";
            if (DecodeToken(token))
            {
                return Ok(_Gate.InsertNewInitiative(initiative));
            }
            else
            {
                return Unauthorized();
            }
           
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetUserSuerviesAnswer([FromQuery]int eventId, [FromHeader] string token)
        {
            if (DecodeToken(token))
            {
                return Ok(_Gate.GetUserSuerviesAnswer(eventId));
            }
            else
            {
                return Unauthorized();
            }
           
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult InsertAddress([FromBody] Address address, [FromHeader] string token)
        {
            if (DecodeToken(token))
            {
                return Ok(_Gate.InsertAddress(address, (int)address.CharityId));
            }
            else
            {
                return Unauthorized();
            }
           
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult InsertService([FromBody]Service service, [FromHeader] string token)
        {
            if (DecodeToken(token))
            {
                return Ok(_Gate.InsertService(service, service.ServiceId));
            }
            else
            {
                return Unauthorized();
            }
           
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult FetchCampagin([FromQuery]int charityId, [FromHeader] string token)
        {

            if (DecodeToken(token))
            {
                return Ok(_Context.DonationCampaigns.Where(record => record.CharityId == charityId)
                 .ToList());
            }
            else
            {
                return Unauthorized();
            }
            

        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult FetchEvents([FromQuery] int charityId, [FromHeader] string token)
        {
            if (DecodeToken(token))
            {
                return Ok(_Context.Initiatives.Where(record => record.CharityId == charityId)
              .ToList());
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
