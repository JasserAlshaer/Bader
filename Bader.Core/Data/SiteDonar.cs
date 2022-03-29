using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class SiteDonar
    {
        public int SiteDonarsId { get; set; }
        public string Email { get; set; }
        public double? Amount { get; set; }
    }
}
