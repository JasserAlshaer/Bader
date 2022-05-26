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


        public bool InsertDonationCampaign(DonationCampaign donationCampaign)
        {
            return _Gate.InsertDonationCampaign(donationCampaign);
        }

        public bool InsertNewInitiative(Initiative initiative)
        {
            return _Gate.InsertNewInitiative(initiative);
        }

        public List<UserSuervy> GetUserSuerviesAnswer(int eventId)
        {
            return _Gate.GetUserSuerviesAnswer(eventId);
        }
        public bool InsertAddress(Address address, int charityID)
        {
            return _Gate.InsertAddress(address, charityID);
        }

        public bool InsertService(Service service, int charityId)
        {
            return _Gate.InsertService(service, charityId);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult FetchCampagin([FromQuery]int charityId)
        {


            return Ok(_Context.DonationCampaigns.Where(record => record.CharityId == charityId)
                .ToList());

        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult FetchEvents([FromQuery] int charityId)
        {


            return Ok(_Context.Initiatives.Where(record => record.InitiativesId == charityId)
               .ToList());




        }





    }
}
