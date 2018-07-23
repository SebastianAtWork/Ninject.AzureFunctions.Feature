using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Host;

namespace Ninject.AzureFunctions.Extensions
{
    public static class HttpRequestExtensions
    {
        public static IActionResult ExecuteFeature<T>(this HttpRequest request, TraceWriter log)
        {

        }
    }
}
