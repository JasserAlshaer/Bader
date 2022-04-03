using Bader.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Bader.Core.Data;
using Bader.Core.DTO;
namespace Bader.Infra.Gate
{
    public class UserGate: IUserGate
    {
        private readonly IUserService _service;

        public UserGate(IUserService service)
        {
            _service = service;
        }
        public WebStaticsDTO GetAllNumericInfo()
        {
            return _service.GetAllNumericInfo();
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
            return _service.FetchDonationCampagin(fillter);
        }

        public List<Initiative> FetchInitiative(InitiativeDTO fillter)
        {
            return _service.FetchInitiative(fillter);
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
