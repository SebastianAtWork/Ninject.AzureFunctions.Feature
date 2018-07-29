using Ninject.AzureFunctions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Host;

namespace Ninject.AzureFunctions
{
    public class AutoFeatureContainer<T> : IDisposable, IAutoFeatureContainer where T: IKernelInizializer
    {
        private readonly IReadOnlyKernel _kernel;

        public AutoFeatureContainer()
        {
            var kernelInizializer = Activator.CreateInstance(typeof(T)) as IKernelInizializer;
            _kernel = kernelInizializer.CreateKernelConfiguration().BuildReadonlyKernel();
        }

        public IReadOnlyKernel Kernel
        {
            get { return _kernel; }
        }

        public async Task<IActionResult> ExecuteFeature<TF>(HttpRequest request, TraceWriter log) where TF : IFeature
        {
            return await Features.ExecuteFeature.Execute(this,typeof(TF), typeof(T), request, log);
        }

        public async Task<IActionResult> ExecuteFeature<TF, TA>(HttpRequest request, TraceWriter log, TA param1) where TF: IFeature<TA>
        {
            return await Features.ExecuteFeature.Execute(this, typeof(TF), typeof(T), request, log, param1);
        }

        public async Task<IActionResult> ExecuteFeature<TF, TA, TB>(HttpRequest request, TraceWriter log, TA param1, TB param2) where TF : IFeature<TA, TB> 
        {
            return await Features.ExecuteFeature.Execute(this, typeof(TF), typeof(T), request, log, param1, param2);
        }

        public async Task<IActionResult> ExecuteFeature<TF, TA, TB, TC>(HttpRequest request, TraceWriter log, TA param1, TB param2, TC param3) where TF : IFeature<TA, TB, TC> 
        {
            return await Features.ExecuteFeature.Execute(this, typeof(TF), typeof(T), request, log, param1, param2, param3);
        }

        public void Dispose()
        {
            _kernel.Dispose();
        }
    }
}
