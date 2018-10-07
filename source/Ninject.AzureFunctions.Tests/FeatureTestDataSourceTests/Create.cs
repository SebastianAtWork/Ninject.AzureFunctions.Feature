using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ninject.AzureFunctions.Contracts;
using Ninject.AzureFunctions.NUnit;
using Ninject.AzureFunctions.Tests.TestNamespace;
using Ninject.AzureFunctions.Tests.TestNamespace.C;
using NUnit.Framework;

namespace Ninject.AzureFunctions.Tests.FeatureTestDataSourceTests
{
    public class Create
    {
        [Test]
        public void CreateTestDataForEveryIFeatureInNamespace()
        {
            var testData = FeatureTestDataSource<RootType, FakeKernelInitializer>.Create();
            Assert.That(testData.Count(), Is.EqualTo(3));
        }

        [Test]
        public void CorrectlyCreateTestData()
        {
            var testData = FeatureTestDataSource<CFeature, FakeKernelInitializer>.Create().Single();

            Assert.That(testData.TestName, Is.EqualTo(nameof(TestNamespace.C) + "." + nameof(CFeature)));
            Assert.That(testData.TypeInfo.Name, Is.EqualTo(nameof(CFeature)));
        }


        internal class FakeKernelInitializer :  IKernelInitializer
        {
            public IKernelConfiguration CreateKernelConfiguration(ILogger log)
            {
                return new KernelConfiguration();
            }
        }
    }
}
