using System;
using System.Collections.Generic;

namespace Biztalk.Monitor.Data.Entities
{
    public partial class AlertSubscription
    {
        public Guid AlertSubscriptionId { get; set; }
        public Guid AlertId { get; set; }
        public bool? Active { get; set; }
        public string Subscriber { get; set; }
        public bool IsGroup { get; set; }
        public string CustomEmail { get; set; }
        public bool UseStartAndEndTime { get; set; }
        public byte? StartUtchour { get; set; }
        public byte? StartUtcminute { get; set; }
        public byte? EndUtchour { get; set; }
        public byte? EndUtcminute { get; set; }
        public DateTime? BlackOutStartDate { get; set; }
        public DateTime? BlackOutEndDate { get; set; }
        public DateTime? LastFired { get; set; }
        public short IntervalMinutes { get; set; }
        public DateTime InsertedDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Alert Alert { get; set; }
    }
}
