using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Charity
    {


        public int CharityId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ProfileImagePath { get; set; }
        public string PreviewVideoPath { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<DonationCampaign> DonationCampaigns { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
