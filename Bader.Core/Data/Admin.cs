using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Admin
    {
        public Admin()
        {
            Logins = new HashSet<Login>();
        }

        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
