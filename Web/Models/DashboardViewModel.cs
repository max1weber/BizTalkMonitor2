using BizTalk.Monitor.Client.Contracts;
using BizTalk.Monitor.Web.Models.TileType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Models
{
    public class DashboardViewModel
    {

        public List<TileTypeViewModel> TileViewModels = new List<TileTypeViewModel>();

        public Application[] BiztalkApps { get; set; }
    }
}
