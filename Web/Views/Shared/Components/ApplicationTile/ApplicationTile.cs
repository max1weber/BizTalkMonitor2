using BizTalk.Monitor.Client.Contracts;
using BizTalk.Monitor.Data.Context;
using BizTalk.Monitor.Web.Models.ApplicationTileType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Views.Shared.Components.ApplicationTile
{
    [ViewComponent(Name ="ApplicationTile")]
    public class ApplicationTile:ViewComponent
    {
        IServiceProvider _provider;
        public ApplicationTile(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<IViewComponentResult> InvokeAsync( Application app)
        {
            EsbExceptionDbContext context = _provider.GetRequiredService<EsbExceptionDbContext>();
          var errors=  await context.Fault.CountAsync(p => p.Application.Equals(app.Name));
            ApplicationTileModel model = new ApplicationTileModel() { Name = app.Name, Errors = errors, Status = app.Status};

            return View(model);
        }
    }
}
