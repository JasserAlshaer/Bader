using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Charity
    {
        public Charity()
        {
            Addresses = new HashSet<Address>();
            DonationCampaigns = new HashSet<DonationCampaign>();
            Links = new HashSet<Link>();
            Logins = new HashSet<Login>();
            Services = new HashSet<Service>();
        }

        public int CharityId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ProfileImagePath { get; set; }
        public string PreviewVideoPath { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }
        public DateTime? DateofEstablishment { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<DonationCampaign> DonationCampaigns { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
