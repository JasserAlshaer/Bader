using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class UserSurveyAnswer
    {
        public int UserSurveyAnswersId { get; set; }
        public int? UserId { get; set; }
        public int? QuestionId { get; set; }
        public int? OptionId { get; set; }
        public string Answer { get; set; }

        public virtual Option Option { get; set; }
        public virtual Question Question { get; set; }
        public virtual UserSuervy User { get; set; }
    }
}
