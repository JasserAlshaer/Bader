using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class UserSuervy
    {
        public int UserSuervyId { get; set; }
        public string Email { get; set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public int? InitiativesId { get; set; }

        public virtual Initiative Initiatives { get; set; }
    }
}
