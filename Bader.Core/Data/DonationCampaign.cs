using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class DonationCampaign
    {
        public DonationCampaign()
        {
            Donors = new HashSet<Donor>();
        }

        public int DonationCampaignsId { get; set; }
        public double? TargetAmount { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string Description { get; set; }
        public int? CharityId { get; set; }

        public virtual Charity Charity { get; set; }
        public virtual ICollection<Donor> Donors { get; set; }
    }
}
