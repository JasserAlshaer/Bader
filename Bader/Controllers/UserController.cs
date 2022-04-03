using Bader.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bader.Core.Data;
using Bader.Core.DTO;
using System.Collections.Generic;
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
        public List<DonationCampaign> FetchDonationCampagin([FromBody]DonationCampaingeRequestDTO fillter)
        {
            return _gate.FetchDonationCampagin(fillter);
        }
        [HttpPost]
        [Route("[action]")]
        public List<Initiative> FetchInitiative([FromBody] InitiativeDTO fillter)
        {
            return _gate.FetchInitiative(fillter);
        }
        [HttpGet]
        [Route("[action]")]
        public WebStaticsDTO GetAllNumericInfo()
        {
            return _gate.GetAllNumericInfo();
        }
    }
}
