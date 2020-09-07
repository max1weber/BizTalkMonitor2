using System;
using System.Collections.Generic;

namespace BizTalk.Monitor.Data.Entities
{
    public partial class Batch
    {
        public Guid BatchId { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime? EndDatetime { get; set; }
        public string ErrorMessage { get; set; }
    }
}
