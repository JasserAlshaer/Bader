using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Initiative
    {
        public Initiative()
        {
            UserSuervies = new HashSet<UserSuervy>();
        }

        public int InitiativesId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int? Duration { get; set; }
        public string ScheduleType { get; set; }
        public int? Seats { get; set; }
        public int? SurveyId { get; set; }
        public int? CharityId { get; set; }

        public virtual Charity Charity { get; set; }
        public virtual ICollection<UserSuervy> UserSuervies { get; set; }
    }
}
