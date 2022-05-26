using System;
using System.Collections.Generic;
using System.Text;
using Bader.Core.Data;

namespace Bader.Core.Gate
{
    public  interface ICharityGate
    {

        public bool InsertNewInitiative(Initiative initiative);

        public bool InsertDonationCampaign(DonationCampaign donationCampaign);

        public bool InsertNewSurvey(Survey survey);

        public List<QuestionType> GetQuestionTypes();

        public bool InsertNewQuestion(Question question);

        public bool InsertNewOption(Option option);

        public List<Question> GetSurveyQuestionsBySurveyId(int surveyId);

        public List<Option> GetOptionsByQuestionId(int questionId);


        public List<UserSuervy> GetUserSuerviesAnswer(int eventId);
        public bool InsertAddress(Address address, int charityID);

        public bool InsertService(Service service, int charityId);









    }
}
