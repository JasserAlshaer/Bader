using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Donor
    {
        public int DonorsId { get; set; }
        public string Name { get; set; }
        public double? Amount { get; set; }
        public int? DonationCampaignsId { get; set; }

        public virtual DonationCampaign DonationCampaigns { get; set; }
    }
}
