using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953502_CHEKHOVICH.Middleware;

namespace WEB_953502_CHEKHOVICH.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }
}
