using System;
using System.Collections.Generic;

namespace Biztalk.Monitor.Data.Entities
{
    public partial class AuditLog
    {
        public Guid AuditLogId { get; set; }
        public Guid ActionTypeId { get; set; }
        public Guid MessageId { get; set; }
        public string NativeMessageId { get; set; }
        public string ContentType { get; set; }
        public string MessageName { get; set; }
        public Guid? FaultId { get; set; }
        public string NativeFaultId { get; set; }
        public string Application { get; set; }
        public string ServiceName { get; set; }
        public string ResubmitUrl { get; set; }
        public string ResubmitCode { get; set; }
        public string ResubmitMessage { get; set; }
        public DateTime AuditDate { get; set; }
        public string AuditUserName { get; set; }
    }
}
