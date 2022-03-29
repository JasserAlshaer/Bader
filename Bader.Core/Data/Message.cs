using System;
using System.Collections.Generic;

#nullable disable

namespace Bader.Core.Data
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string SenderMail { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
