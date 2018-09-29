using System.Diagnostics;
using Ninject.AzureFunctions.Contracts;

namespace Ninject.AzureFunctions.Tests.Utility
{
        public class FakeKernelContainer : IAutoFeatureContainer
        {
            public IReadOnlyKernel Kernel { get; }

            public FakeKernelContainer()
            {
                var kernelConfig = new TestKernel()
                    .CreateKernelConfiguration(new FakeTraceWriter(TraceLevel.Verbose));
                Kernel = kernelConfig.BuildReadonlyKernel();
            }
        }
}
