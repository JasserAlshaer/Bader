using Bader.Core.Gate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
