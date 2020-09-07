using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Models.TileType
{
    public class TileTypeViewModel
    {

        public TileTypeViewModel()
        {
            Contents = new List<TileTypeContent>();
        }


        public string TileCssClass { get; set; } = "tile wide quote";
        public string TileTitle { get; set; }
        public List<TileTypeContent>    Contents{ get; set; }
    }
}
