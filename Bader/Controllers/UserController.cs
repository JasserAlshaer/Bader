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
        [HttpGet]
        [Route("[action]")]
        public double GetDonationSummaation() { 
          return _gate.GetDonationSummaation();
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
        public Charity GetCharityById(int id){
            return _gate.GetCharityById(id);
        }
        [HttpGet]
        [Route("[action]")]
        public List<Charity> GetCharityByName([FromQuery] string name){
            return _gate.GetCharityByName(name);
        }
        [HttpGet]
        [Route("[action]")]
        public Initiative GetInitiativeById([FromQuery] int id){
            return _gate.GetInitiativeById(id);
        }
        [HttpGet]
        [Route("[action]")]
        public DonationCampaign GetDonationCampaignById([FromQuery] int id){
            return _gate.GetDonationCampaignById((int)id);
        }
        [HttpPost]
        [Route("[action]")]
        public bool DonateForSpecificDonationCampaign([FromBody] Donor donor){
            return _gate.DonateForSpecificDonationCampaign(donor);
        }
        [HttpGet]
        [Route("[action]")]
        public Survey GetSurveyById([FromQuery] int id){

            return _gate.GetSurveyById((int)id);
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


    }
}
