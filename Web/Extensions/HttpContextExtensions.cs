using BizTalk.Monitor.Web.Data;
using BizTalk.Monitor.Web.Models.Tenant;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalk.Monitor.Web.Extensions
{

    /// <summary>
    /// Extensions to HttpContext to make multi-tenancy easier to use
    /// </summary>

    public static class HttpContextExtensions
    {
        /// <summary>
        /// Returns the current tenant
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        public static T GetTenant<T>(this HttpContext context) where T : Tenant
        {
            if (context == null || !context.Items.ContainsKey(Constants.HttpContextTenantKey))
                return null;
            return context.Items[Constants.HttpContextTenantKey] as T;
        }

        /// <summary>
        /// Returns the current Tenant
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Tenant GetTenant(this HttpContext context)
        {
            return context.GetTenant<Tenant>();
        }
    }
}
