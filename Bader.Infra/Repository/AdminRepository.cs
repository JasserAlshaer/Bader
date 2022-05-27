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

        private readonly BaderContext _context;

        public AdminRepository(BaderContext context)
        {
            _context = context;
        }


        public List<Message> GetAllUserMessages()
        {
            return _context.Messages.ToList(); 
        }

        public WebStaticsDTO GetAllWebSiteStatics()
        {
            WebStaticsDTO webStaticsDTO = new WebStaticsDTO();
            webStaticsDTO.SummationOfInitiatives = _context.Initiatives.Count();
            webStaticsDTO.SummationOfSubscriber = _context.Subscribers.Count();
            webStaticsDTO.SummationOfDonationCampainge = _context.DonationCampaigns.Count();
            webStaticsDTO.SummationOfDonations = _context.SiteDonars.Sum(x => x.Amount).Value; ;
            webStaticsDTO.Charities=_context.Charities.Count();
            webStaticsDTO.UserMassages=_context.Messages.Count();
            webStaticsDTO.Donors=_context.Donors.Count()+_context.SiteDonars.Count();
            return webStaticsDTO;
        }

        public List<Subscriber> GetAllWebSiteSubscriberInformation()
        {
            return _context.Subscribers.ToList();
        }

        public List<Charity> GetCharitiesJoinRequests()
        {
            return _context.Charities.Where(x=>x.IsActive==false).ToList();
        }


        public bool ResponseToUserMassage(ResponseDTO response)
        {
            //Email Sender Code
            throw new NotImplementedException();
        }
    }
}
