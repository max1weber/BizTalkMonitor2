using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Models
{
    public class DashboardViewModel
    {

        public int TotalNumberOfFaults { get; set; }

        public int TotalNumberOfProcessedFaults { get; set; }

        public int FaultsToday { get; set; }

        public int FaultsProcessedToday { get; set; }


    }
}
