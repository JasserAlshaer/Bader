using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string CardNumber { get; set; }
        public string Cvv2 { get; set; }
        public DateTime? ExpireDate { get; set; }
        public double? Balance { get; set; }
    }
}
