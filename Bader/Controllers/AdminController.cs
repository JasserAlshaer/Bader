using Bader.Core.Data;
using Bader.Core.Gate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminDoor adminDoor;


        public AdminController(IAdminDoor adminDoor)
        {
            this.adminDoor = adminDoor;
        }

        [HttpGet]
        [Route("[action]")]
        public List<Subscriber> GetAllWebSiteSubscriberInformation()
        {
            return adminDoor.GetAllWebSiteSubscriberInformation();
        }

    }
}
