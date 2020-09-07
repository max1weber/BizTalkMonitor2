using BizTalk.Monitor.Web.Data;
using BizTalk.Monitor.Web.Models.Tenant;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Helpers
{
    public class TenantDbStore : ITenantStore<Tenant>
    {

        DbContext _ctx;

        public TenantDbStore(ApplicationDbContext dbContext)
        {
            _ctx = dbContext;
        }
        public Task<Tenant> GetTenantAsync(string identifier)
        {
           var dbset =  _ctx.Set<Tenant>();

           return dbset.SingleOrDefaultAsync(p => p.Identifier.Equals(identifier));
        }
    }
}
