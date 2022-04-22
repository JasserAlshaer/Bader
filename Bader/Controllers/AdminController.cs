﻿using Bader.Core.Data;
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


        public AdminController(IAdminDoor adminDoor)
        {
            this._adminGate = adminDoor;
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

        [HttpGet]
        [Route("[action]")]
        public List<Subscriber> GetAllWebSiteSubscriberInformation()
        {
            return _adminGate.GetAllWebSiteSubscriberInformation();
        }


        public List<Message> GetAllUserMessages()
        {
            return _adminGate.GetAllUserMessages();
        }

        public WebStaticsDTO GetAllWebSiteStatics()
        {
            return _adminGate.GetAllWebSiteStatics();
        }

        public bool ResponseToUserMassage(ResponseDTO response)
        {
            return _adminGate.ResponseToUserMassage(response);
        }

    }
}
