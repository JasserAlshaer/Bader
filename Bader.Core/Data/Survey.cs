using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Survey
    {
        public Survey()
        {
            Questions = new HashSet<Question>();
            UserSuervies = new HashSet<UserSuervy>();
        }

        public int SurveyId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<UserSuervy> UserSuervies { get; set; }
    }
}
