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
