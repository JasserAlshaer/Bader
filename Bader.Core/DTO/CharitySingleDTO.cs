using Bader.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.DTO
{
    public class CharitySingleDTO
    {
        public int CharityId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ProfileImagePath { get; set; }
        public string PreviewVideoPath { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }
        public DateTime? DateofEstablishment { get; set; }
        public List<Address>Addresses { get; set; }
        public List<Service> Services { get; set; }

    }
}
