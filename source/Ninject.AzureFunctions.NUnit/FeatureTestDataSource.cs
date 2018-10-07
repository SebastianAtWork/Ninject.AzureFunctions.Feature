using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject.AzureFunctions.Contracts;

namespace Ninject.AzureFunctions.NUnit
{
    public static class FeatureTestDataSource
    {
        public static IEnumerable<FeatureTestData> Create(Type namespaceRootType)
        {
            var rootNamespace = namespaceRootType.Namespace;
            var typesOfNamespace =
                namespaceRootType.Assembly.DefinedTypes.Where(t => t?.Namespace?.StartsWith(rootNamespace)??false);
            var featureTypes = typesOfNamespace.Where(t => t.GetInterface(nameof(IFeature)) != null);
            return featureTypes.Select(f => ConvertToTestData(f, rootNamespace));
        }

        private static FeatureTestData ConvertToTestData(TypeInfo featureType, string rootNamespace)
        {
            return new FeatureTestData()
            {
                TestName = featureType.Namespace.Substring(rootNamespace.Length-1,featureType.Namespace.Length- (rootNamespace.Length - 1)) + "." + featureType.Name,
                TypeInfo  = featureType
            };
        }
    }
}
