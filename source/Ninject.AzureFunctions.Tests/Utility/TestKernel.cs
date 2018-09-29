using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Ninject.AzureFunctions.Contracts;
using Ninject.AzureFunctions.Tests.ExecuteFeatureTests;

namespace Ninject.AzureFunctions.Tests.Utility
{
    public class TestKernel : IKernelInizializer
    {
        public IKernelConfiguration CreateKernelConfiguration(TraceWriter log)
        {
            var config = new KernelConfiguration();

            config.Bind<IFakeService>().To<FakeService>().InSingletonScope();
            config.Bind<TraceWriter>().ToConstant(log);

            return config;
        }
    }
}
