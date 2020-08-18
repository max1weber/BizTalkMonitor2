using System;
using System.Collections.Generic;

namespace BizTalk.Monitor.Data.Entities
{
    public partial class AlertEmail
    {
        public Guid AlertEmailId { get; set; }
        public Guid AlertSubscriptionHistoryId { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool Sent { get; set; }
        public Guid BatchId { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
