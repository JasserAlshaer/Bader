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

        public bool ResponseToUserMassage(ResponseDTO response);


        public WebStaticsDTO GetAllWebSiteStatics();
    }
}
