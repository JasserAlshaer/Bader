using Bader.Core.Data;
using Bader.Core.Gate;
using Bader.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Infra.Gate
{
    public class CharityGate : ICharityGate
    {

        private readonly ICharityService _Service;

        public CharityGate(ICharityService service)
        {
            _Service = service;
        }
        public List<Option> GetOptionsByQuestionId(int questionId)
        {
            return _Service.GetOptionsByQuestionId(questionId);
        }

        public List<QuestionType> GetQuestionTypes()
        {
            return _Service.GetQuestionTypes();
        }

        public List<Question> GetSurveyQuestionsBySurveyId(int surveyId)
        {
            return _Service.GetSurveyQuestionsBySurveyId((int)surveyId);
        }

        public bool InsertDonationCampaign(DonationCampaign donationCampaign)
        {
            return _Service.InsertDonationCampaign(donationCampaign);
        }

        public bool InsertNewInitiative(Initiative initiative)
        {
            return _Service.InsertNewInitiative(initiative);
        }

        public bool InsertNewOption(Option option)
        {
            return _Service.InsertNewOption(option);
        }

        public bool InsertNewQuestion(Question question)
        {
            return _Service.InsertNewQuestion(question);
        }

        public bool InsertNewSurvey(Survey survey)
        {
            return _Service.InsertNewSurvey(survey);
        }

        public List<UserSuervy> GetUserSuerviesAnswer(int eventId)
        {
            return _Service.GetUserSuerviesAnswer(eventId);
        }
        public bool InsertAddress(Address address, int charityID)
        {
            return _Service.InsertAddress(address, charityID);
        }

        public bool InsertService(Service service, int charityId)
        {
            return _Service.InsertService(service, charityId);
        }


    }
}
