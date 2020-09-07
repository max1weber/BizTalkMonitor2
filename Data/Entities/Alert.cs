using System;
using System.Collections.Generic;

namespace BizTalk.Monitor.Data.Entities
{
    public partial class Alert
    {
        public Alert()
        {
            AlertCondition = new HashSet<AlertCondition>();
            AlertSubscription = new HashSet<AlertSubscription>();
        }

        public Guid AlertId { get; set; }
        public string Name { get; set; }
        public string ConditionsString { get; set; }
        public DateTime InsertedDate { get; set; }
        public string InsertedBy { get; set; }

        public virtual ICollection<AlertCondition> AlertCondition { get; set; }
        public virtual ICollection<AlertSubscription> AlertSubscription { get; set; }
    }
}
