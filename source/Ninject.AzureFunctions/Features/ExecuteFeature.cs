using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Ninject.AzureFunctions.Contracts;

namespace Ninject.AzureFunctions.Features
{
    public static class ExecuteFeature
    {

        public static async Task<IActionResult> Execute(IAutoFeatureContainer kernelContainer,Type typeofFeature, Type typeofKernelInitializer, HttpRequest request, TraceWriter log, params object[] callingParams)
        {
           

            var feature = kernelContainer.Kernel.Get(typeofFeature);

            var methodInfo = feature.GetType().GetMethod(nameof(IFeature.Execute));

            IActionResult result = null;

            if (request.ContentLength > 0)
            {
                var bodySerialized = await request.ReadAsStringAsync();
                var typeofBody = methodInfo.GetParameters()[0].ParameterType;
                var bodyDeserialized = JsonConvert.DeserializeObject(bodySerialized, typeofBody);
                var parameters = new List<object>();
                parameters.Add(bodyDeserialized);
                parameters.AddRange(callingParams);
                result = methodInfo.Invoke(feature, parameters.ToArray()) as IActionResult;

            }
            else
            {
                result = methodInfo.Invoke(feature, callingParams.ToArray()) as IActionResult;
            }

            return result;
        }
    }
}
