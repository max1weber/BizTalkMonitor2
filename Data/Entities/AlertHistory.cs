using System;
using System.Collections.Generic;

namespace Biztalk.Monitor.Data.Entities
{
    public partial class AlertHistory
    {
        public AlertHistory()
        {
            AlertSubscriptionHistory = new HashSet<AlertSubscriptionHistory>();
        }

        public Guid AlertHistoryId { get; set; }
        public string AlertName { get; set; }
        public Guid FaultId { get; set; }
        public string Application { get; set; }
        public string ServiceName { get; set; }
        public DateTime InsertedDate { get; set; }

        public virtual ICollection<AlertSubscriptionHistory> AlertSubscriptionHistory { get; set; }
    }
}
