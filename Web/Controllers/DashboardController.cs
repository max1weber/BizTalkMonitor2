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
    public class DashboardController : Controller
    {
        EsbExceptionDbContext _ctx;
        public DashboardController(EsbExceptionDbContext context)
        {
            _ctx = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
