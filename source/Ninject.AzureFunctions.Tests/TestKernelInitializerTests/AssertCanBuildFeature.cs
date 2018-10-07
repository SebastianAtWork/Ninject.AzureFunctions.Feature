using System;
using Microsoft.Extensions.Logging;
using Ninject.AzureFunctions.Contracts;
using Ninject.AzureFunctions.NUnit;
using Ninject.AzureFunctions.Tests.Utility;
using NUnit.Framework;

namespace Ninject.AzureFunctions.Tests.TestKernelInitializerTests
{
    public class AssertCanBuildFeature
    {
        [Test]
        public void CanBuildFeature()
        {
            var featureTestData = new FeatureTestData()
            {
                TestName = nameof(CanDoFeature),
                TypeInfo = typeof(CanDoFeature)
            };

            TestKernelInitializer.AssertCanBuildFeature<CanDoKernelInitializer>(featureTestData);
        }

        [Test]
        public void CannotBuildFeature()
        {
            var featureTestData = new FeatureTestData()
            {
                TestName = nameof(NoCanDoFeature),
                TypeInfo = typeof(NoCanDoFeature)
            };

            try
            {
                TestKernelInitializer.AssertCanBuildFeature<CanDoKernelInitializer>(featureTestData);
            }
            catch (AssertionException)
            {
                
            }
        }


        internal class CanDoFeature : IFeature
        {
            public CanDoFeature(ILogger log)
            {
                
            }
        }

        internal class NoCanDoFeature : IFeature
        {
            public NoCanDoFeature(IFakeService service)
            {

            }
        }
        internal class CanDoKernelInitializer : IKernelInitializer
        {
            public IKernelConfiguration CreateKernelConfiguration(ILogger log)
            {
                var config = new KernelConfiguration();

                config.Bind<ILogger>().ToConstant(log);

                return config;
            }
        }
    }
}
