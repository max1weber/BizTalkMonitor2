using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizTalk.Monitor.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BizTalk.Monitor.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        internal EsbExceptionDbContext _ctx { get; private set; }
        public BaseController(EsbExceptionDbContext context)
        {
            _ctx = context;
        }
    }
}
