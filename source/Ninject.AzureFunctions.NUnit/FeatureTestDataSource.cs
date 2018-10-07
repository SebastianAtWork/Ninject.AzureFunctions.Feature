using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject.AzureFunctions.Contracts;

namespace Ninject.AzureFunctions.NUnit
{
    public static class FeatureTestDataSource<TRootType,TKernelInitializer> where TKernelInitializer : IKernelInitializer
    {
        public static IEnumerable TestCases
        {
            get { return Create(); }
        }

        public static IEnumerable<FeatureTestData> Create()
        {
            var namespaceRootType = typeof(TRootType);
            var rootNamespace = namespaceRootType.Namespace;
            var typesOfNamespace =
                namespaceRootType.Assembly.DefinedTypes.Where(t => t?.Namespace?.StartsWith(rootNamespace)??false);
            var featureTypes = typesOfNamespace.Where(t => t.GetInterface(nameof(IFeature)) != null);
            var kernelInitializer = Activator.CreateInstance<TKernelInitializer>();
            return featureTypes.Select(f => ConvertToTestData(f, rootNamespace, kernelInitializer.CreateKernelConfiguration(new FakeLogger())));
        }

        private static FeatureTestData ConvertToTestData(TypeInfo featureType, string rootNamespace,
            IKernelConfiguration kernelConfiguration)
        {
            return new FeatureTestData()
            {
                TestName = featureType.Namespace.Substring(rootNamespace.Length-1,featureType.Namespace.Length- (rootNamespace.Length - 1)) + "." + featureType.Name,
                TypeInfo  = featureType,
                KernelConfiguration = kernelConfiguration
            };
        }
    }
}
