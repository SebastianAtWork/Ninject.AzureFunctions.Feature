using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.AzureFunctions.NUnit;
using Ninject.AzureFunctions.Tests.TestNamespace;
using NUnit.Framework;

namespace Ninject.AzureFunctions.Tests.FeatureTestDataSourceTests
{
    public class Create
    {
        [Test]
        public void CreateTestDataForEveryIFeatureInNamespace()
        {
            var testData = FeatureTestDataSource.Create(typeof(RootType));
            Assert.That(testData.Count(),Is.EqualTo(3));
        }
    }
}
