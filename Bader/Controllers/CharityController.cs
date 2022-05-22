using Bader.Core.Data;
using Bader.Core.Gate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Bader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharityController : ControllerBase
    {
        private readonly ICharityGate _Gate;


        public CharityController(ICharityGate gate)
        {
            this._Gate = gate;
        }


        enum RoleType
        {
            NoOne, Admin, Employee
        }


        public int DecodeToken(String tokenString)
        {

            String toke = "Bearer " + tokenString;

            var jwtEncodedString = toke.Substring(7);

            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);

            int roleType = Int32.Parse((token.Claims.First(c => c.Type == "role").Value.ToString()));
            if (roleType == 1 && token.ValidTo >= DateTime.Now)
            {

                return (int)RoleType.Admin;
            }
            else if (roleType == 2 && token.ValidTo >= DateTime.Now)
            {

                return (int)RoleType.Employee;
            }
            else
            {


                return (int)RoleType.NoOne;
            }
        }

        public List<Option> GetOptionsByQuestionId(int questionId)
        {
            return _Gate.GetOptionsByQuestionId(questionId);
        }

        public List<QuestionType> GetQuestionTypes()
        {
            return _Gate.GetQuestionTypes();
        }

        public List<Question> GetSurveyQuestionsBySurveyId(int surveyId)
        {
            return _Gate.GetSurveyQuestionsBySurveyId((int)surveyId);
        }

        public bool InsertDonationCampaign(DonationCampaign donationCampaign)
        {
            return _Gate.InsertDonationCampaign(donationCampaign);
        }

        public bool InsertNewInitiative(Initiative initiative)
        {
            return _Gate.InsertNewInitiative(initiative);
        }

        public bool InsertNewOption(Option option)
        {
            return _Gate.InsertNewOption(option);
        }

        public bool InsertNewQuestion(Question question)
        {
            return _Gate.InsertNewQuestion(question);
        }

        public bool InsertNewSurvey(Survey survey)
        {
            return _Gate.InsertNewSurvey(survey);
        }

       

    }
}
