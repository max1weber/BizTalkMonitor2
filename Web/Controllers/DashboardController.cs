using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BizTalk.Monitor.Data.Context;
using BizTalk.Monitor.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BizTalk.Monitor.Web.Controllers
{
  
    [Authorize]
    public class DashboardController : BaseController
    {


        public DashboardController(EsbExceptionDbContext context) : base(context)
        {

        }
        public async Task<IActionResult> IndexAsync()
        {
            var lastdatetime = DateTime.Now.AddDays(-1);
            DashboardViewModel model = new DashboardViewModel()
            {

                TotalNumberOfFaults = await _ctx.Fault.CountAsync(),
                TotalNumberOfProcessedFaults = await _ctx.ProcessedFault.CountAsync(),
                FaultsToday = _ctx.Fault.Where(p => p.DateTime.HasValue && (p.DateTime.Value.Date >= lastdatetime.Date)).Count(),
                FaultsProcessedToday = _ctx.AuditLog.Where(p => p.AuditDate >= lastdatetime.Date).Count()

            };
            return View(model);
        }
    }
}
