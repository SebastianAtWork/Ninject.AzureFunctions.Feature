using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using Ninject.AzureFunctions.Contracts;

namespace Example.Host.Features
{
    public class AwesomeFeature : IFeature
    {
        private readonly IExampleRepository _exampleRepository;

        public AwesomeFeature(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<string> Execute(int id)
        {
            return "1";
        }
    }
}
