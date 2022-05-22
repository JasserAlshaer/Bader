using Bader.Core.Data;
using Bader.Core.Repository;
using Bader.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Infra.Services
{
    public class CharityService : ICharityService
    {

        private readonly ICharityRepository _repos;

        public CharityService(ICharityRepository repo)
        {
            _repos = repo;
        }
        public List<Option> GetOptionsByQuestionId(int questionId)
        {
           return _repos.GetOptionsByQuestionId(questionId);
        }

        public List<QuestionType> GetQuestionTypes()
        {
           return _repos.GetQuestionTypes();
        }

        public List<Question> GetSurveyQuestionsBySurveyId(int surveyId)
        {
           return _repos.GetSurveyQuestionsBySurveyId((int)surveyId);   
        }

        public bool InsertDonationCampaign(DonationCampaign donationCampaign)
        {
           return _repos.InsertDonationCampaign(donationCampaign);
        }

        public bool InsertNewInitiative(Initiative initiative)
        {
           return _repos.InsertNewInitiative(initiative);
        }

        public bool InsertNewOption(Option option)
        {
           return _repos.InsertNewOption(option);
        }

        public bool InsertNewQuestion(Question question)
        {
           return _repos.InsertNewQuestion(question);
        }

        public bool InsertNewSurvey(Survey survey)
        {
            return _repos.InsertNewSurvey(survey);
        }

       
    }
}
