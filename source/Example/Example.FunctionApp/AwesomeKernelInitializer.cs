using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.AzureFunctions.Contracts;

namespace Example.FunctionApp
{
    public class AwesomeKernelInitializer : IKernelInizializer
    {
        public IKernelConfiguration CreateKernelConfiguration()
        {
            return new KernelConfiguration();
        }
    }
}
