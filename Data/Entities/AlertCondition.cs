using System;
using System.Collections.Generic;

namespace BizTalk.Monitor.Data.Entities
{
    public partial class AlertCondition
    {
        public Guid AlertConditionId { get; set; }
        public Guid AlertId { get; set; }
        public string LeftSide { get; set; }
        public string RightSide { get; set; }
        public string Operator { get; set; }
        public DateTime InsertedDate { get; set; }

        public virtual Alert Alert { get; set; }
    }
}
