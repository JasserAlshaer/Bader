using Bader.Core.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Bader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly BaderContext SystemContext;

        public TestController(BaderContext currentContext)
        {
            SystemContext = currentContext;
        }

        [HttpGet]
        public List<Admin> GetAdmins()
        {
            return SystemContext.Admins.ToList();
        }
    }
}
