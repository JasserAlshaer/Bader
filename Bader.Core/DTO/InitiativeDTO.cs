using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.DTO
{
    public class InitiativeDTO
    {
        public int InitiativesId { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }

        public int? Duration { get; set; }
        public string ScheduleType { get; set; }
    }
}
