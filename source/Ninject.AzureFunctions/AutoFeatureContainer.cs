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

        public AutoFeatureContainer(TraceWriter log)
        {
            var kernelInizializer = Activator.CreateInstance(typeof(T)) as IKernelInizializer;
            _kernel = kernelInizializer.CreateKernelConfiguration(log).BuildReadonlyKernel();
        }

        public IReadOnlyKernel Kernel
        {
            get { return _kernel; }
        }

        public async Task<IActionResult> ExecuteFeature<TF>(HttpRequest request) where TF : IFeature
        {
            return await Features.ExecuteFeature.Execute(this,typeof(TF), typeof(T), request);
        }

        public async Task<IActionResult> ExecuteFeature<TF, TA>(HttpRequest request, TA param1) where TF: IFeature<TA>
        {
            return await Features.ExecuteFeature.Execute(this, typeof(TF), typeof(T), request, param1);
        }

        public async Task<IActionResult> ExecuteFeature<TF, TA, TB>(HttpRequest request, TA param1, TB param2) where TF : IFeature<TA, TB> 
        {
            return await Features.ExecuteFeature.Execute(this, typeof(TF), typeof(T), request, param1, param2);
        }

        public async Task<IActionResult> ExecuteFeature<TF, TA, TB, TC>(HttpRequest request, TA param1, TB param2, TC param3) where TF : IFeature<TA, TB, TC> 
        {
            return await Features.ExecuteFeature.Execute(this, typeof(TF), typeof(T), request, param1, param2, param3);
        }

        public void Dispose()
        {
            _kernel.Dispose();
        }
    }
}
