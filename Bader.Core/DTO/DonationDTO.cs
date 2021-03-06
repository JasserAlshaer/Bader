using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.DTO
{
    public class DonationDTO
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public string DonationCampaignsId { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string Cvv2 { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
