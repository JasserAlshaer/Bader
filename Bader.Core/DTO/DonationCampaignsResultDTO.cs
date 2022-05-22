using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.DTO
{
    public class DonationCampaignsResultDTO
    {
        public int DonationCampaignsId { get; set; }
        public double? TargetAmount { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string Description { get; set; }
        public int? CharityId { get; set; }
        public double Sum { get; set; }
    }
}
