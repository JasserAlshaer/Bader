using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Gate;
using Bader.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Infra.Gate
{
    public class AdminGate : IAdminDoor
    {
        private readonly IAdminService adminService;

        public AdminGate(IAdminService admin)
        {
            adminService= admin;
        }
        public List<Message> GetAllUserMessages()
        {
            return adminService.GetAllUserMessages();
        }

        public WebStaticsDTO GetAllWebSiteStatics()
        {
            return adminService.GetAllWebSiteStatics();
        }

        public List<Subscriber> GetAllWebSiteSubscriberInformation()
        {
            return adminService.GetAllWebSiteSubscriberInformation();
        }

        public bool ResponseToUserMassage(ResponseDTO response)
        {
            return adminService.ResponseToUserMassage(response);
        }
    }
}
