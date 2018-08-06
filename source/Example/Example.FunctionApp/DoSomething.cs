
using System.IO;
using System.Threading.Tasks;
using Example.Host.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Ninject.AzureFunctions;

namespace Example.FunctionApp
{
    public static class DoSomething
    {
        [FunctionName("DoSomething")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "DoSomething/{id:int}")]HttpRequest req,int id, TraceWriter log)
        {
            using (var autoContainer = new AutoFeatureContainer<AwesomeKernelInitializer>(log))
            {
                return await autoContainer.ExecuteFeature<AwesomeFeature,int>(req, id);
            }
        }
    }
}
