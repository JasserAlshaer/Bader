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
            throw new NotImplementedException();
        }

        public List<QuestionType> GetQuestionTypes()
        {
            throw new NotImplementedException();
        }

        public List<Question> GetSurveyQuestionsBySurveyId(int surveyId)
        {
            throw new NotImplementedException();
        }

        public bool InsertDonationCampaign(DonationCampaign donationCampaign)
        {
            throw new NotImplementedException();
        }

        public bool InsertNewInitiative(Initiative initiative)
        {
            throw new NotImplementedException();
        }

        public bool InsertNewOption(Option option)
        {
            throw new NotImplementedException();
        }

        public bool InsertNewQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public bool InsertNewSurvey(Survey survey)
        {
            throw new NotImplementedException();
        }

        public bool InsertUserAnswerForSurvey()
        {
            throw new NotImplementedException();
        }
    }
}
