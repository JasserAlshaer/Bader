using Bader.Core.Data;
using Bader.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.Repository
{
    public  interface IUserRepository
    {
        public bool DonateToWebSite(double amount);

        public bool InsertMessageRecords(Message message);

        public List<DonationCampaign> FetchDonationCampagin(DonationCampaingeRequestDTO fillter);
        
        public List<Initiative> FetchInitiative(InitiativeDTO fillter);

        public double GetDonationSummaation();

        public bool DonateToSite(SiteDonar siteDonar);

        public List<Charity> GetAllCharity();
        public Charity GetCharityById(int id);

        public List<Charity> GetCharityByName(string name);

        public Initiative GetInitiativeById(int id);

        public DonationCampaign GetDonationCampaignById(int id);

        public bool DonateForSpecificDonationCampaign(Donor donor);

        public Survey GetSurveyById(int id);

        public bool SubscribeTheSite(Subscriber subscriber);

        public bool InsertMassage(Message message);
        

    }
}
