using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ninject.AzureFunctions.NUnit
{
    public class FeatureTestData
    {
        public string RelativeNamespace { get; set; }
        public TypeInfo TypeInfo { get; set; }
    }
}
