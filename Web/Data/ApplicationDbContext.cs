using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using BizTalk.Monitor.Web.Models.Tenant;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BizTalk.Monitor.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        DbSet<Tenant> Tenant { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tenant>()
                    .Property(b => b.Items)
                    .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v));
        }
    }
}
