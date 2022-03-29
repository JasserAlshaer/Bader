using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Service
    {
        public int ServiceId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string TargetUser { get; set; }
        public int? TotalBeneficiaries { get; set; }
        public DateTime? StartAt { get; set; }
        public int? CharityId { get; set; }

        public virtual Charity Charity { get; set; }
    }
}
