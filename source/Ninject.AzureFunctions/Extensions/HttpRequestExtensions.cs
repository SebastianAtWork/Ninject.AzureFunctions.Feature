using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Host;
using Ninject.AzureFunctions.Contracts;
using Ninject.AzureFunctions.Features;

namespace Ninject.AzureFunctions.Extensions
{
    public static class HttpRequestExtensions
    {
        public static IActionResult ExecuteFeature<T, TK>(this HttpRequest request, TraceWriter log) where T : IFeature where TK : IKernelInizializer
        {
            return Features.ExecuteFeature.Execute(typeof(T), typeof(TK), request, log);
        }

        public static IActionResult ExecuteFeature<T, TA, TK>(this HttpRequest request, TraceWriter log) where T : IFeature<TA> where TK : IKernelInizializer
        {
            return Features.ExecuteFeature.Execute(typeof(T), typeof(TK), request, log);
        }

        public static IActionResult ExecuteFeature<T, TA, TB, TK>(this HttpRequest request, TraceWriter log) where T : IFeature<TA, TB> where TK : IKernelInizializer
        {
            return Features.ExecuteFeature.Execute(typeof(T), typeof(TK), request, log);
        }

        public static IActionResult ExecuteFeature<T, TA, TB, TC, TK>(this HttpRequest request, TraceWriter log) where T : IFeature<TA, TB, TC> where TK : IKernelInizializer
        {
            return Features.ExecuteFeature.Execute(typeof(T), typeof(TK), request, log);
        }

        public static IActionResult ExecuteFeature<T, TA, TB, TC, TD, TK>(this HttpRequest request, TraceWriter log) where T : IFeature<TA, TB, TC, TD> where TK : IKernelInizializer
        {
            return Features.ExecuteFeature.Execute(typeof(T), typeof(TK), request, log);
        }
    }
}
