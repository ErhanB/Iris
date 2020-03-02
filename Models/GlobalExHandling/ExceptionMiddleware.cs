using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iris.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Iris.Models.GlobalExHandling
{
    public class ExceptionMiddleware
    {

            private readonly RequestDelegate _next;

            public ExceptionMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext httpContext)
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            private void Log(HttpContext context, Exception exception, IHostingEnvironment hostingEnvironment)
            {
                var savePath = hostingEnvironment.WebRootPath;
                var now = DateTime.UtcNow;
                var fileName = $"{now.ToString("yyyy_MM_dd")}.log";
                var filePath = Path.Combine(savePath, "logs", fileName);

                
                new FileInfo(filePath).Directory.Create();

                using (var writer = File.CreateText(filePath))
                {
                    writer.WriteLine($"{now.ToString("HH:mm:ss")} {context.Request.Path}");
                    writer.WriteLine(exception.Message);
                }
            }
        }
    }
