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
            return adminRepository.GetAllUserMessages();
        }

        public WebStaticsDTO GetAllWebSiteStatics()
        {
            return adminRepository.GetAllWebSiteStatics();
        }

        public List<Subscriber> GetAllWebSiteSubscriberInformation()
        {
            return adminRepository.GetAllWebSiteSubscriberInformation();
        }

      

        public List<Charity> GetCharitiesJoinRequests()
        {
            return adminRepository.GetCharitiesJoinRequests();

        }
    }
}
