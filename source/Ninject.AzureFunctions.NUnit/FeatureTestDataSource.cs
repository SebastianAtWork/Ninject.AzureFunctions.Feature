using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject.AzureFunctions.NUnit
{
    public static class FeatureTestDataSource
    {
        public static IEnumerable<FeatureTestData> Create(Type namespaceRootType)
        {
            return Enumerable.Empty<FeatureTestData>();
        }
    }
}
