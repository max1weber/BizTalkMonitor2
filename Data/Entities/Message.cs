using System;
using System.Collections.Generic;

namespace Biztalk.Monitor.Data.Entities
{
    public partial class Message
    {
        public Guid MessageId { get; set; }
        public string NativeMessageId { get; set; }
        public Guid FaultId { get; set; }
        public string ContentType { get; set; }
        public string MessageName { get; set; }
        public string InterchangeId { get; set; }
        public string RoutingUrl { get; set; }
        public bool ResubmitAttempted { get; set; }
        public bool ResubmitSuccessful { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string ActivityId { get; set; }
    }
}
