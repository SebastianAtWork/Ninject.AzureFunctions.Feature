using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Contracts.Repositories;
using Ninject.AzureFunctions.Contracts;

namespace Example.Host.Features
{
    public class AwesomeFeature : IFeature<string,int>
    {
        private readonly IExampleRepository _exampleRepository;

        public AwesomeFeature(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<int> Execute(string param)
        {
            return 1;
        }
    }
}
