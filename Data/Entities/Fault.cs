using System;
using System.Collections.Generic;

namespace Biztalk.Monitor.Data.Entities
{
    public partial class Fault
    {
        public Guid FaultId { get; set; }
        public string NativeMessageId { get; set; }
        public string ActivityId { get; set; }
        public string Application { get; set; }
        public string Description { get; set; }
        public string ErrorType { get; set; }
        public string FailureCategory { get; set; }
        public string FaultCode { get; set; }
        public string FaultDescription { get; set; }
        public int? FaultSeverity { get; set; }
        public string Scope { get; set; }
        public string ServiceInstanceId { get; set; }
        public string ServiceName { get; set; }
        public string FaultGenerator { get; set; }
        public string MachineName { get; set; }
        public DateTime? DateTime { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionTargetSite { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string InnerExceptionMessage { get; set; }
        public bool? InsertMessagesFlag { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
