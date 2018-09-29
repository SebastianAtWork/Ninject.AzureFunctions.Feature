using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Host;
using Ninject.AzureFunctions.Contracts;
using Ninject.AzureFunctions.Features;
using NUnit.Framework;

namespace Ninject.AzureFunctions.Tests.ExecuteFeatureTests
{
    public class ExecuteActionTests
    {
        [Test]
        public async Task ExecutesActionFeature()
        {
            var kernelContainer = new FakeKernelContainer();
            var fakeService = kernelContainer.Kernel.Get<IFakeService>();

            var result =
                await ExecuteFeature.ExecuteAction<ActionFeature>(kernelContainer, f => f.Execute("Test")) as
                    OkObjectResult;

            Assert.That(fakeService.Value, Is.EqualTo("Test"));
            Assert.That(result, Is.Not.Null);
            var resultContent = result.Value;
            Assert.That(resultContent, Is.EqualTo("Bla"));
        }

        [Test]
        public async Task ExecutesActionFeatureThrowsException()
        {
            var kernelContainer = new FakeKernelContainer();

            var result =
                await ExecuteFeature.ExecuteAction<ActionFeatureWithException>(kernelContainer, f => f.Execute("Test"));

            Assert.That(result.GetType(), Is.EqualTo(typeof(InternalServerErrorResult)));
        }

        internal class FakeKernelContainer : IAutoFeatureContainer
        {
            public IReadOnlyKernel Kernel { get; }

            public FakeKernelContainer()
            {
                var kernelConfig = new ActionFeatureKernel()
                    .CreateKernelConfiguration(new FakeTraceWriter(TraceLevel.Verbose));
                Kernel = kernelConfig.BuildReadonlyKernel();
            }
        }

        internal class ActionFeatureKernel : IKernelInizializer
        {
            public IKernelConfiguration CreateKernelConfiguration(TraceWriter log)
            {
                var config = new KernelConfiguration();

                config.Bind<IFakeService>().To<FakeService>().InSingletonScope();
                config.Bind<TraceWriter>().ToConstant(log);

                return config;
            }
        }

        internal class ActionFeature : IFeature
        {
            private readonly IFakeService _fakeService;

            public ActionFeature(IFakeService fakeService)
            {
                _fakeService = fakeService;
            }

            public async Task<IActionResult> Execute(string value)
            {
                _fakeService.SetValue(value);
                return await Task.FromResult(new OkObjectResult("Bla"));
            }
        }

        internal class ActionFeatureWithException : IFeature
        {
            private readonly IFakeService _fakeService;

            public ActionFeatureWithException(IFakeService fakeService)
            {
                _fakeService = fakeService;
            }

            public async Task<IActionResult> Execute(string value)
            {
                await Task.Run(() => throw new ArgumentException());
                return new OkObjectResult("Bla");
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
