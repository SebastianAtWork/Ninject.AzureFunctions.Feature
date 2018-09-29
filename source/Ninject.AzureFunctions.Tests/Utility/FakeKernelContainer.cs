﻿using System.Diagnostics;
using Ninject.AzureFunctions.Contracts;

namespace Ninject.AzureFunctions.Tests.Utility
{
        public class FakeKernelContainer : IAutoFeatureContainer
        {
            public IReadOnlyKernel Kernel { get; }

            public FakeKernelContainer()
            {
                var kernelConfig = new TestKernel()
                    .CreateKernelConfiguration(new FakeLogger());
                Kernel = kernelConfig.BuildReadonlyKernel();
            }
        }
}
