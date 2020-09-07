using System;
using System.Collections.Generic;

namespace BizTalk.Monitor.Data.Entities
{
    public partial class Configuration
    {
        public Guid ConfigurationId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
