using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Models.Tenant
{
    /// <summary>
    /// Tenant information
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// The tenant Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The tenant identifier
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Tenant items
        /// </summary>
        public Dictionary<string, string> Items { get; private set; } = new Dictionary<string, string>();
    }
}
