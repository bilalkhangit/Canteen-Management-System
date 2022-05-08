using Microsoft.AspNetCore.Http;
using NLog.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen_Management_System.Api.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            //var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var str = $"Request = Method: {context.Request.Method}, Path: {context.Request.Path}";
            logger.Info(str);

            await _next(context);
        }
    }
}
