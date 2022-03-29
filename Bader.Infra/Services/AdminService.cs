using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Repository;
using Bader.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Infra.Services
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository adminRepository;


        public AdminService(IAdminRepository adminRepository)
        {
                this.adminRepository = adminRepository;
        }
        public List<Message> GetAllUserMessages()
        {
            throw new NotImplementedException();
        }

        public WebStaticsDTO GetAllWebSiteStatics()
        {
            throw new NotImplementedException();
        }

        public List<Subscriber> GetAllWebSiteSubscriberInformation()
        {
            return adminRepository.GetAllWebSiteSubscriberInformation();
        }

        public bool ResponseToUserMassage(ResponseDTO response)
        {
            throw new NotImplementedException();
        }
    }
}
