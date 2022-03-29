using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Subscriber
    {
        public int SubscriberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? JoiningDate { get; set; }
    }
}
