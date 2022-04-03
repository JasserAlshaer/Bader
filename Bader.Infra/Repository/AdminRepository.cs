using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bader.Infra.Repository
{
    public class AdminRepository : IAdminRepository
    {

        private readonly AnsamContext _context;

        public AdminRepository(AnsamContext context)
        {
            _context = context;
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
            return _context.Subscribers.ToList();
        }

        public List<Message> GetUsersMessages()
        {
            throw new NotImplementedException();
        }

        public bool ResponseToUserMassage(ResponseDTO response)
        {
            throw new NotImplementedException();
        }
    }
}
