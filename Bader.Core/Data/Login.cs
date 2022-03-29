using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Login
    {
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastLogout { get; set; }
        public int? AdminId { get; set; }
        public int? CharityId { get; set; }
        public int? RoleId { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Charity Charity { get; set; }
        public virtual Role Role { get; set; }
    }
}
