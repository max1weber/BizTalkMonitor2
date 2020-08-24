using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizTalk.Monitor.Client;
using BizTalk.Monitor.Client.Contracts;
using BizTalk.Monitor.Data.Context;
using BizTalk.Monitor.Web.Extensions;
using BizTalk.Monitor.Web.Models.Tenant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BizTalk.Monitor.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {

        
        internal EsbExceptionDbContext _ctx { get; private set; }
        internal IApplicationsClient _appClient { get; private set; }
        public BaseController(IServiceProvider serviceProvider)
        {
           
            _appClient = serviceProvider.GetRequiredService<IApplicationsClient>();
            _ctx = serviceProvider.GetService<EsbExceptionDbContext>();
        }
    }
}
