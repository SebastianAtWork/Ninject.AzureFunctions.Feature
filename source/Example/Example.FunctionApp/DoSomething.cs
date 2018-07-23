
using System.IO;
using Example.Host.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Ninject.AzureFunctions.Extensions;

namespace Example.FunctionApp
{
    public static class DoSomething
    {
        [FunctionName("DoSomething")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "DoSomething/{id:int}")]HttpRequest req, TraceWriter log)
        {
            return req.ExecuteFeature<AwesomeFeature>(log);
        }
    }
}
