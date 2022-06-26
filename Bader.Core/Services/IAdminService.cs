using Bader.Core.Data;
using Bader.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.Services
{
    public interface IAdminService
    {

        public List<Subscriber> GetAllWebSiteSubscriberInformation();

        public List<Message> GetAllUserMessages();

        

        public List<Charity> GetCharitiesJoinRequests();
        public WebStaticsDTO GetAllWebSiteStatics();
    }
}
