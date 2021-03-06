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
        //public bool DonateForSpecificDonationCampaign(Donor donor)
        //{
        //    return _repository.DonateForSpecificDonationCampaign(donor);
        //}

        public WebStaticsDTO GetAllNumericInfo()
        {
            return _repository.GetAllNumericInfo();
        }


        public bool DonateToSite(DonationDTO siteDonar)
        {
            return _repository.DonateToSite(siteDonar);
        }



        public List<DonationCampaignsResultDTO> FetchDonationCampagin(DonationCampaingeRequestDTO fillter)
        {
            return _repository.FetchDonationCampagin(fillter);
        }

        public List<Initiative> FetchInitiative(InitiativeDTO fillter)
        {
            return _repository.FetchInitiative(fillter);
        }

        public List<Charity> GetAllCharity()
        {
            return _repository.GetAllCharity();
        }

        public CharitySingleDTO GetCharityById(int id)
        {
            return _repository.GetCharityById(id);
        }

        public List<Charity> GetCharityByName(string name)
        {
            return _repository.GetCharityByName(name);
        }

        public DonationCampaign GetDonationCampaignById(int id)
        {
            return _repository.GetDonationCampaignById(id);
        }

        public double GetDonationSummaation()
        {
            return _repository.GetDonationSummaation();
        }

        public Initiative GetInitiativeById(int id)
        {
            return _repository.GetInitiativeById(id);
        }

        public Survey GetSurveyById(int id)
        {
            return _repository.GetSurveyById(id);
        }

        public bool InsertMassage(Message message)
        {
            return _repository.InsertMassage(message);
        }



        public bool SubscribeTheSite(SubscriberDto subscriber)
        {
            return _repository.SubscribeTheSite(subscriber);
        }

        public bool InsertUserAnswerForSurvey(SurveyDTO surveyAnswer)
        {
            UserSuervy userSuervy = new UserSuervy();
            userSuervy.Age = surveyAnswer.Age;
            userSuervy.Name = surveyAnswer.Name;
            userSuervy.Email = surveyAnswer.Email;
            userSuervy.Date = DateTime.Now;
            userSuervy.InitiativesId = Convert.ToInt32(surveyAnswer.InitiativesId);
            userSuervy.PhoneNumber = surveyAnswer.PhoneNumber;
            return _repository.InsertUserAnswerForSurvey(userSuervy);
        }
    }
}
