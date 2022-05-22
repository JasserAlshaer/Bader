using Bader.Core.Data;
using Bader.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.Services
{
    public interface IUserGate
    {
        //public bool DonateToWebSite(double amount);

        //public bool InsertMessageRecords(Message message);

        public List<DonationCampaignsResultDTO> FetchDonationCampagin(DonationCampaingeRequestDTO fillter);

        public List<Initiative> FetchInitiative(InitiativeDTO fillter);

        public double GetDonationSummaation();


        public WebStaticsDTO GetAllNumericInfo();
        public bool DonateToSite(DonationDTO siteDonar);

        public List<Charity> GetAllCharity( );
        public Charity GetCharityById(int id);

        public List<Charity> GetCharityByName(string name);

        public Initiative GetInitiativeById(int id);

        public DonationCampaign GetDonationCampaignById(int id);

        public bool DonateForSpecificDonationCampaign(Donor donor);

        public Survey GetSurveyById(int id);

        public bool SubscribeTheSite(SubscriberDto subscriber);

        public bool InsertMassage(Message message);

        public bool InsertUserAnswerForSurvey(UserSuervy surveyAnswer);

    }
}
