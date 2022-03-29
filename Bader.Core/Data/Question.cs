using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public int? QuestionTypeId { get; set; }
        public bool? IsRequierd { get; set; }
        public int SuervyId { get; set; }

        public virtual QuestionType QuestionType { get; set; }
        public virtual Survey Suervy { get; set; }
    }
}
