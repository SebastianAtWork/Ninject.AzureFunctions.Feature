using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ninject.AzureFunctions.NUnit
{
    public class FeatureTestData : TestCaseData
    {
        public Type TypeInfo { get; set; }
    }
}
