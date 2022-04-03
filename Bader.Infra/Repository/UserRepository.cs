using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bader.Infra.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly AnsamContext _context;

        public UserRepository(AnsamContext context)
        {
            _context = context;
        }
        public bool DonateForSpecificDonationCampaign(Donor donor)
        {
            throw new NotImplementedException();
        }

        public bool DonateToSite(SiteDonar siteDonar)
        {
            throw new NotImplementedException();
        }

        public bool DonateToWebSite(double amount)
        {
            throw new NotImplementedException();
        }

        public List<DonationCampaign> FetchDonationCampagin(DonationCampaingeRequestDTO fillter)
        {
            return _context.DonationCampaigns.DefaultIfEmpty().ToList();
        }

        public List<Initiative> FetchInitiative(InitiativeDTO fillter)
        {
            return _context.Initiatives.DefaultIfEmpty().ToList();
        }

        public List<Charity> GetAllCharity()
        {
            throw new NotImplementedException();
        }

        public Charity GetCharityById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Charity> GetCharityByName(string name)
        {
            throw new NotImplementedException();
        }

        public DonationCampaign GetDonationCampaignById(int id)
        {
            throw new NotImplementedException();
        }

        public double GetDonationSummaation()
        {
            throw new NotImplementedException();
        }

        public Initiative GetInitiativeById(int id)
        {
            throw new NotImplementedException();
        }

        public WebStaticsDTO GetAllNumericInfo()
        {
            WebStaticsDTO webStaticsDTO = new WebStaticsDTO();
            webStaticsDTO.SummationOfInitiatives = _context.Initiatives.Count();
            webStaticsDTO.SummationOfSubscriber = _context.Subscribers.Count();
            webStaticsDTO.SummationOfDonationCampainge=_context.DonationCampaigns.Count();
            webStaticsDTO.SummationOfDonations = 0;
            return webStaticsDTO;
        }

        public Survey GetSurveyById(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertMassage(Message message)
        {
            throw new NotImplementedException();
        }

        public bool InsertMessageRecords(Message message)
        {
            throw new NotImplementedException();
        }

        public bool SubscribeTheSite(Subscriber subscriber)
        {
            throw new NotImplementedException();
        }
    }
}
