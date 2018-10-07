using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ninject.AzureFunctions.Contracts;
using NUnit.Framework;

namespace Ninject.AzureFunctions.NUnit
{
    public static class TestKernelInitializer
    {
        public static void AssertCanBuildFeature<TKernelInitializer>(FeatureTestData featureTestData) where TKernelInitializer : IKernelInitializer
        {
            var kernelInitializer = Activator.CreateInstance<TKernelInitializer>();
            var fakeLogger = new FakeLogger();
            using (var kernel = kernelInitializer.CreateKernelConfiguration(fakeLogger).BuildReadonlyKernel())
            {
                try
                {
                    kernel.Get(featureTestData.TypeInfo);
                }
                catch (ActivationException e)
                {
                    throw new AssertionException($"Cannot resolve {featureTestData.TestName}",e);
                }
            }
        }
    }
}
