using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.DTO
{
    public class DonationCampaingeRequestDTO
    {
        public double? TargetAmount { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int? CharityId { get; set; }
    }
}
