using System;
using System.Collections.Generic;

namespace BizTalk.Monitor.Data.Entities
{
    public partial class ContextProperty
    {
        public Guid ContextPropertyId { get; set; }
        public Guid MessageId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
