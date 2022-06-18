using Bader.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Bader.Core.Data;
using Bader.Core.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Bader.Infra.Gate
{
    public class UserGate: IUserGate
    {
        private readonly IUserService _service;

        public UserGate(IUserService service)
        {
            _service = service;
        }


        //************************************************
        public WebStaticsDTO GetAllNumericInfo()
        {
            return _service.GetAllNumericInfo();
        }
        //public bool DonateForSpecificDonationCampaign(Donor donor)
        //{
        //    return _service.DonateForSpecificDonationCampaign(donor);
        //}

        public bool DonateToSite(DonationDTO siteDonar)
        {
            return _service.DonateToSite(siteDonar);
        }

       

        public List<DonationCampaignsResultDTO> FetchDonationCampagin(DonationCampaingeRequestDTO fillter)
        {
            return _service.FetchDonationCampagin(fillter);
        }

        public List<Initiative> FetchInitiative(InitiativeDTO fillter)
        {
            return _service.FetchInitiative(fillter);
        }

        public List<Charity> GetAllCharity( )
        {
            return _service.GetAllCharity();
        }

        public CharitySingleDTO GetCharityById(int id)
        {
            return _service.GetCharityById(id);
        }

        public List<Charity> GetCharityByName(string name)
        {
            return _service.GetCharityByName(name);
        }

        public DonationCampaign GetDonationCampaignById(int id)
        {
            return _service.GetDonationCampaignById(id);   
        }

        public double GetDonationSummaation()
        {
            return _service.GetDonationSummaation();
        }

        public Initiative GetInitiativeById(int id)
        {
            return _service.GetInitiativeById(id);
        }

        public Survey GetSurveyById(int id)
        {
            return _service.GetSurveyById(id);
        }

        public bool InsertMassage(Message message)
        {

            return _service.InsertMassage(message);
        }



        public bool SubscribeTheSite(SubscriberDto subscriber)
        {
            return _service.SubscribeTheSite(subscriber);
        }


        public bool InsertUserAnswerForSurvey(SurveyDTO surveyAnswer)
        {
            return _service.InsertUserAnswerForSurvey(surveyAnswer);
        }
    }
}
