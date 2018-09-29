﻿using System;
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
    public class ExecuteOkTests
    {
        [Test]
        public async Task ExecutesOkFeature()
        {
            var kernelContainer = new FakeKernelContainer();
            var fakeService = kernelContainer.Kernel.Get<IFakeService>();

            var result = await ExecuteFeature.ExecuteOk<OkFeature,string>(kernelContainer, f => f.Execute("Test")) as OkObjectResult;

            Assert.That(fakeService.Value, Is.EqualTo("Test"));
            Assert.That(result, Is.Not.Null);
            var resultContent = result.Value;
            Assert.That(resultContent,Is.EqualTo("Bla"));
        }

        [Test]
        public async Task ExecutesOkFeatureThrowsException()
        {
            var kernelContainer = new FakeKernelContainer();

            var result = await ExecuteFeature.ExecuteOk<OkFeatureWithException,string>(kernelContainer, f => f.Execute("Test"));

            Assert.That(result.GetType(), Is.EqualTo(typeof(InternalServerErrorResult)));
        }

        internal class FakeKernelContainer : IAutoFeatureContainer
        {
            public IReadOnlyKernel Kernel { get; }

            public FakeKernelContainer()
            {
                var kernelConfig = new OkFeatureKernel()
                    .CreateKernelConfiguration(new FakeTraceWriter(TraceLevel.Verbose));
                Kernel = kernelConfig.BuildReadonlyKernel();
            }
        }

        internal class OkFeatureKernel : IKernelInizializer
        {
            public IKernelConfiguration CreateKernelConfiguration(TraceWriter log)
            {
                var config = new KernelConfiguration();

                config.Bind<IFakeService>().To<FakeService>().InSingletonScope();
                config.Bind<TraceWriter>().ToConstant(log);

                return config;
            }
        }

        internal class OkFeature : IFeature
        {
            private readonly IFakeService _fakeService;

            public OkFeature(IFakeService fakeService)
            {
                _fakeService = fakeService;
            }

            public async Task<string> Execute(string value)
            {
                _fakeService.SetValue(value);
                return await Task.FromResult("Bla");
            }
        }
        internal class OkFeatureWithException : IFeature
        {
            private readonly IFakeService _fakeService;

            public OkFeatureWithException(IFakeService fakeService)
            {
                _fakeService = fakeService;
            }

            public async Task<string> Execute(string value)
            {
                await Task.Run(()=>throw new ArgumentException());
                return value;
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
