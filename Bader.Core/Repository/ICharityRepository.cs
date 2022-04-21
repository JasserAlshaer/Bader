using Bader.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.Repository
{
    public  interface ICharityRepository
    {

        public bool InsertNewInitiative(Initiative initiative);

        public bool InsertDonationCampaign(DonationCampaign donationCampaign);

        public bool InsertNewSurvey(Survey survey);

        public List<QuestionType> GetQuestionTypes();

        public bool InsertNewQuestion(Question question);

        public bool InsertNewOption(Option option);

        public List<Question> GetSurveyQuestionsBySurveyId(int surveyId);

        public List<Option> GetOptionsByQuestionId(int questionId);
        public bool InsertUserAnswerForSurvey(UserSurveyAnswer userSurveyAnswer);




    }
}
