using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject.AzureFunctions.Contracts
{
    public interface IKernelInizializer
    {
        IKernelConfiguration CreateKernelConfiguration();
    }
}
