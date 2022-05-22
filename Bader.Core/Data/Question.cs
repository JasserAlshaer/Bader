using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Question
    {
        public Question()
        {
            UserSurveyAnswers = new HashSet<UserSurveyAnswer>();
        }

        public int QuestionId { get; set; }
        public string Title { get; set; }
        public int? QuestionTypeId { get; set; }
        public bool? IsRequierd { get; set; }
        public int? SurveyId { get; set; }

        public virtual QuestionType QuestionType { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ICollection<UserSurveyAnswer> UserSurveyAnswers { get; set; }
    }
}
