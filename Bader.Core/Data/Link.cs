using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Link
    {
        public int LinksId { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instgram { get; set; }
        public string WhatsApp { get; set; }
        public string LinkedIn { get; set; }
        public string WebSite { get; set; }
        public int? CharityId { get; set; }

        public virtual Charity Charity { get; set; }
    }
}
