using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json.Serialization;
using Ninject.AzureFunctions.Contracts;
using Ninject.AzureFunctions.Features;
using NUnit.Framework;

namespace Ninject.AzureFunctions.Tests.ExecuteFeatureTests
{
    public class ExecuteVoidTests
    {
        [Test]
        public async Task ExecutesVoidFeature()
        {
            var kernelContainer = new FakeKernelContainer();
            var fakeService = kernelContainer.Kernel.Get<IFakeService>();

            await ExecuteFeature.ExecuteVoid<VoidFeature>(kernelContainer, f => f.Execute("Test"));

            Assert.That(fakeService.Value,Is.EqualTo("Test"));
        }

        internal class FakeKernelContainer : IAutoFeatureContainer
        {
            public IReadOnlyKernel Kernel { get; }

            public FakeKernelContainer()
            {
                var kernelConfig = new VoidFeatureKernel()
                    .CreateKernelConfiguration(new ConsoleTraceWriter(TraceLevel.Verbose));
                Kernel = kernelConfig.BuildReadonlyKernel();
            }
        }

        internal class VoidFeatureKernel : IKernelInizializer
        {
            public IKernelConfiguration CreateKernelConfiguration(TraceWriter log)
            {
                var config = new KernelConfiguration();

                config.Bind<IFakeService>().To<FakeService>().InSingletonScope();
                config.Bind<TraceWriter>().ToConstant(log);

                return config;
            }
        }

        internal class VoidFeature : IFeature
        {
            private readonly IFakeService _fakeService;

            public VoidFeature(IFakeService fakeService)
            {
                _fakeService = fakeService;
            }

            public async Task Execute(string value)
            {
                _fakeService.SetValue(value);
            }
        }

        internal class FakeService : IFakeService
        {
            public string Value { get; set; }
            public void SetValue(string value)
            {
                Value = value;
            }
        }

        internal interface IFakeService
        {
            string Value { get; set; }

            void SetValue(string value);

        }
    }
}
