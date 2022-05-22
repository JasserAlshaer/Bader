using Bader.Core.Data;
using Bader.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bader.Infra.Repository
{
    public class CharityRepository : ICharityRepository
    {
        private readonly BaderContext _context;

        public CharityRepository(BaderContext context)
        {
            _context = context;
        }
        public List<Option> GetOptionsByQuestionId(int questionId)
        {
            return _context.Options.Where(x=>x.QuestionId==questionId).ToList();
        }

        public List<QuestionType> GetQuestionTypes()
        {
            return _context.QuestionTypes.ToList();
        }

        public List<Question> GetSurveyQuestionsBySurveyId(int surveyId)
        {
            return _context.Questions.Where(x=>x.SuervyId==surveyId).ToList();
        }

        public bool InsertDonationCampaign(DonationCampaign donationCampaign)
        {
            _context.Add(donationCampaign);
            _context.SaveChanges();
            return true;
        }

        public bool InsertNewInitiative(Initiative initiative)
        {
            _context.Add(initiative);
            _context.SaveChanges();
            return true;
        }

        public bool InsertNewOption(Option option)
        {
            _context.Add(option);
            _context.SaveChanges();
            return true;
        }

        public bool InsertNewQuestion(Question question)
        {
            _context.Add(question);
            _context.SaveChanges();
            return true;
        }

        public bool InsertNewSurvey(Survey survey)
        {
            _context.Add(survey);
            _context.SaveChanges();
            return true;
        }

       
    }
}
