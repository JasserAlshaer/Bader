using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Repository;
using Bader.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Infra.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repos)
        {
            _repository = repos;
        }
        public bool DonateForSpecificDonationCampaign(Donor donor)
        {
            throw new NotImplementedException();
        }

        public WebStaticsDTO GetAllNumericInfo()
        {
            return _repository.GetAllNumericInfo();
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
            return _repository.FetchDonationCampagin(fillter);
        }

        public List<Initiative> FetchInitiative(InitiativeDTO fillter)
        {
            return _repository.FetchInitiative(fillter);
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
