using Bader.Core.Gate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharityController : ControllerBase
    {
        private readonly ICharityGate _Gate;


        public CharityController(ICharityGate gate)
        {
            this._Gate = gate;
        }

    }
}
