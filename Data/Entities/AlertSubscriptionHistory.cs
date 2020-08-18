using System;
using System.Collections.Generic;

namespace Biztalk.Monitor.Data.Entities
{
    public partial class AlertSubscriptionHistory
    {
        public Guid AlertSubscriptionHistoryId { get; set; }
        public Guid AlertHistoryId { get; set; }
        public string Subscriber { get; set; }
        public bool IsGroup { get; set; }
        public string CustomEmail { get; set; }
        public DateTime InsertedDate { get; set; }

        public virtual AlertHistory AlertHistory { get; set; }
    }
}
