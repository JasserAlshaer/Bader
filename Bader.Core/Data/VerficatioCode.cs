using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class VerficatioCode
    {
        public int VerficatioCodeId { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public DateTime? GeneratedAt { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
