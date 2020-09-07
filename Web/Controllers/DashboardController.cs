using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BizTalk.Monitor.Client;
using BizTalk.Monitor.Data.Context;
using BizTalk.Monitor.Web.Models;
using BizTalk.Monitor.Web.Models.TileType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BizTalk.Monitor.Web.Controllers
{
  
    [Authorize]
    public class DashboardController : BaseController
    {
        

        public DashboardController(IServiceProvider provider) : base(provider)
        {

        }
        public async Task<IActionResult> IndexAsync()
        {
            var lastdatetime = DateTime.Now.AddDays(-1);
            var appsResponse = await _appClient.GetAsync();



            var totalNumberOfFaults = await _ctx.Fault.CountAsync();
            var totalNumberOfProcessedFaults = await _ctx.ProcessedFault.CountAsync();
            var faultsToday = _ctx.Fault.Where(p => p.InsertedDate >= lastdatetime.Date).Count();
            var faultsProcessedToday = _ctx.AuditLog.Where(p => p.AuditDate >= lastdatetime.Date).Count();

            ///data total tile
            List<TileTypeContent> contentTotal = new List<TileTypeContent>();
            contentTotal.Add(new TileTypeContent() { DisplayTitle = "Total Failures", DisplayValue = totalNumberOfFaults.ToString() });
            contentTotal.Add(new TileTypeContent() { DisplayTitle = "Total Failures Processed", DisplayValue = totalNumberOfProcessedFaults.ToString() });
            TileTypeViewModel totalTile = new TileTypeViewModel() { TileCssClass = "tile wide resource", TileTitle = "Total Numbers", Contents = contentTotal };

            //data today tile
            List<TileTypeContent> todayTotal = new List<TileTypeContent>();
            todayTotal.Add(new TileTypeContent() { DisplayTitle = "Today Failures", DisplayValue = faultsToday.ToString() });
            todayTotal.Add(new TileTypeContent() { DisplayTitle = "Today  Processed", DisplayValue = faultsProcessedToday.ToString() });
            TileTypeViewModel todayTile = new TileTypeViewModel() { TileCssClass = "tile wide quote", TileTitle = "Total Today", Contents = todayTotal };

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            dashboardViewModel.TileViewModels.Add(totalTile);
            dashboardViewModel.TileViewModels.Add(todayTile);

            if (appsResponse.StatusCode == 200)
            {
                var excludedApp = appsResponse.Result.Where(p => p.Status.Contains("NotApplicable", StringComparison.InvariantCultureIgnoreCase));
                dashboardViewModel.BiztalkApps = appsResponse.Result.Except(excludedApp).ToArray();
            }

            return View(dashboardViewModel);
        }
    }
}
