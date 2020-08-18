using System;
using System.Collections.Generic;

namespace Biztalk.Monitor.Data.Entities
{
    public partial class VwAggregatedFaults
    {
        public int? FaultCount { get; set; }
        public string Application { get; set; }
        public string ServiceName { get; set; }
        public string ErrorType { get; set; }
        public string ExceptionType { get; set; }
        public string FaultCode { get; set; }
        public string FailureCategory { get; set; }
        public int? FaultSeverity { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Hour { get; set; }
        public DateTime? DateTime { get; set; }
        public DateTime? TrueDateTime { get; set; }
    }
}
