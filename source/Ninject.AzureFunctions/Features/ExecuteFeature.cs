using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Host;

namespace Ninject.AzureFunctions.Features
{
    public static class ExecuteFeature
    {

        public static IActionResult Execute(Type typeofFeature, Type typeofKernelInitializer, HttpRequest request, TraceWriter log)
        {
            return new OkObjectResult("Hello");
        }
    }
}
