using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BizTalk.Monitor.Data.Context;
using BizTalk.Monitor.Data.Entities;
using BizTalk.Monitor.Web.Models;
using BizTalk.Monitor.Web.ViewComponents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BizTalk.Monitor.Web.Controllers
{
    [Authorize]
    public class DevOpsController : BaseController
    {
        public DevOpsController(EsbExceptionDbContext context):base(context)
        {
            
        }
        public async Task<IActionResult> IndexAsync(int? pageIndex =1)
        {

            var faults = await _ctx.Fault.AsNoTracking().OrderByDescending(p=>p.InsertedDate).ToListAsync();

            PaginatedList<Fault> faultsModel = PaginatedList<Fault>.Create(faults, pageIndex ?? 1, 50, 3);

            return View(faultsModel);
        }

        public async Task<IActionResult> FaultDetails(Guid id)
        {
            FaultDataViewModel fdvm = new FaultDataViewModel();
            var fault = await _ctx.Fault.FirstOrDefaultAsync(p => p.FaultId.Equals(id));
            fdvm.Fault = fault;
            if (fault != null)
            {
                var message = await _ctx.Message.FirstOrDefaultAsync(p => p.FaultId.Equals(id));
                fdvm.Message = message;
            }

            

            return View(fdvm);
        }

        public async Task<IActionResult> MessageContent(Guid id)
        {

            var content = await _ctx.MessageData.FirstOrDefaultAsync(p => p.MessageId.Equals(id));

            return Ok(content);
        }
    }
}
