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
        public int? SuervyId { get; set; }

        public virtual Survey Suervy { get; set; }
    }
}
