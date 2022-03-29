using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            Questions = new HashSet<Question>();
        }

        public int QuestionTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
