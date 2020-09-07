using System;
using System.Collections.Generic;

namespace BizTalk.Monitor.Data.Entities
{
    public partial class AuditLogMessageData
    {
        public Guid AuditLogId { get; set; }
        public string MessageData { get; set; }
    }
}
