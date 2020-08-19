using BizTalk.Monitor.Web.Models.TileType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Views.Shared.Components.Tile

{ 
    [ViewComponent(Name = "tile")]
    public class TileViewComponent : ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync(TileTypeViewModel tileViewModel)
        {


            return View(tileViewModel);
        }
    }
}
