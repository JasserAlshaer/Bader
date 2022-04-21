using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Option
    {
        public Option()
        {
            UserSurveyAnswers = new HashSet<UserSurveyAnswer>();
        }

        public int OptionId { get; set; }
        public string Text { get; set; }
        public int? QuestionId { get; set; }

        public virtual ICollection<UserSurveyAnswer> UserSurveyAnswers { get; set; }
    }
}
