using Bader.Core.Data;
using Bader.Core.Gate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Bader.Core.DTO;

namespace Bader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminDoor _adminGate;





        public bool DecodeToken(String tokenString)
        {

            String toke = "Bearer " + tokenString;

            var jwtEncodedString = toke.Substring(7);

            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);

            int roleId = Int32.Parse((token.Claims.First(c => c.Type == "RoleId").Value.ToString()));
            if (roleId == 1 && token.ValidTo > DateTime.Now)
            {

                return true;
            }
            else
            {

                return false;
            }


        }

        public AdminController(IAdminDoor adminDoor)
        {
            this._adminGate = adminDoor;
        }
        enum RoleType
        {
            NoOne, Admin, Employee
        }


      

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllWebSiteSubscriberInformation([FromHeader]string token)

        {
            if (DecodeToken(token))
            {
                return Ok(_adminGate.GetAllWebSiteSubscriberInformation());
            }
            else
            {
                return Unauthorized();
            }
            
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllUserMessages([FromHeader] string token)
        {
            
            if(DecodeToken(token))
            {
                return Ok(_adminGate.GetAllUserMessages());
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllWebSiteStatics([FromHeader] string token)
        {
            if (DecodeToken(token))
            {
                return Ok(_adminGate.GetAllWebSiteStatics());
            }
            else
            {
                return Unauthorized();
            }
           
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCharitiesJoinRequests([FromHeader] string token)
        {
           
            if (DecodeToken(token))
            {
                return Ok(_adminGate.GetCharitiesJoinRequests());
            }
            else
            {
                return Unauthorized();
            }
        }




    }
}
