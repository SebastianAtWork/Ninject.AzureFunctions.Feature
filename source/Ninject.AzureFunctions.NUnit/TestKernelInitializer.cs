using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ninject.AzureFunctions.Contracts;

namespace Ninject.AzureFunctions.NUnit
{
    public static class TestKernelInitializer
    {
        public static void AssertCanBuildFeature<TKernelInitializer>(FeatureTestData featureTestData) where TKernelInitializer : IKernelInitializer
        {
            var kernelInitializer = Activator.CreateInstance<IKernelInitializer>();
            var fakeLogger = new FakeLogger();
            using (var kernel = kernelInitializer.CreateKernelConfiguration(fakeLogger).BuildReadonlyKernel())
            {
                kernel.Get(featureTestData.TypeInfo);
            }
        }
    }
}
