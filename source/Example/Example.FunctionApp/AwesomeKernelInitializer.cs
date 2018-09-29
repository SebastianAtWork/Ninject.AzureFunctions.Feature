using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Contracts;
using Example.Contracts.Repositories;
using Example.Repositories;
using Microsoft.Azure.WebJobs.Host;
using Ninject;
using Ninject.AzureFunctions.Contracts;

namespace Example.FunctionApp
{
    public class AwesomeKernelInitializer : IKernelInitializer
    {
        public IKernelConfiguration CreateKernelConfiguration(TraceWriter log)
        {
            var config =  new KernelConfiguration();

            config.Bind<IExampleRepository>().To<ExampleRepository>();
            config.Bind<Configuration>().ToConstant(new Configuration());
            config.Bind<TraceWriter>().ToConstant(log);

            return config;
        }
    }
}
