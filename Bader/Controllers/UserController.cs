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
        private readonly BaderContext _context;
        public readonly IUserGate _gate;
       public UserController(IUserGate gate, BaderContext context)
        {
            _gate = gate;
            this._context = context;
        }

      


        [HttpPost]
        [Route("[action]")]
        public IActionResult FetchDonationCampagin([FromBody]DonationCampaingeRequestDTO fillter)
        {


           return Ok(_gate.FetchDonationCampagin(fillter));
          
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult FetchInitiative([FromBody] InitiativeDTO fillter)
        {
            

      

                return Ok(_gate.FetchInitiative(fillter));
    
            
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllNumericInfo()
        {
                return Ok(_gate.GetAllNumericInfo());  
        }
        
        [HttpPost]
        [Route("[action]")]
        public bool DonateToSite([FromBody] DonationDTO siteDonar) {
            return _gate.DonateToSite(siteDonar);
          }
        [HttpGet]
        [Route("[action]")]
        public List<Charity> GetAllCharity() {
            return _gate.GetAllCharity();
        }
        [HttpGet]
        [Route("[action]")]
        public CharitySingleDTO GetCharityById([FromQuery]int id){
            return _gate.GetCharityById(id);
        }
        [HttpGet]
        [Route("[action]")]
        public List<Charity> GetCharityByName([FromQuery] string name){
            return _gate.GetCharityByName(name);
        }

        [HttpPost]
        [Route("[action]")]
        public bool SubscribeTheSite([FromBody] SubscriberDto subscriber){


            return _gate.SubscribeTheSite(subscriber);


        }

        [HttpPost]
        [Route("[action]")]
        public bool InsertMassage([FromBody] Message message){

            return _gate.InsertMassage(message);


        }


        [HttpPost]
        [Route("[action]")]
        public bool InsertUserAnswerForSurvey([FromBody] SurveyDTO surveyAnswer)
        {
            return _gate.InsertUserAnswerForSurvey(surveyAnswer);
        }


    }
}
