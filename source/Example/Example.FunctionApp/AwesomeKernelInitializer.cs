using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Contracts;
using Example.Contracts.Repositories;
using Example.Repositories;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.AzureFunctions.Contracts;

namespace Example.FunctionApp
{
    public class AwesomeKernelInitializer : IKernelInitializer
    {
        public IKernelConfiguration CreateKernelConfiguration(ILogger log)
        {
            var config =  new KernelConfiguration();

            config.Bind<IExampleRepository>().To<ExampleRepository>();
            config.Bind<Configuration>().ToConstant(new Configuration());
            config.Bind<ILogger>().ToConstant(log);

            return config;
        }
    }
}
