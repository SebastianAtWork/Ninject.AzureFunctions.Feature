using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Contracts.Repositories;

namespace Example.Host.Features
{
    public class DoSomething
    {
        private readonly IExampleRepository _exampleRepository;

        public DoSomething(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public int Execute(string param)
        {
            return 1;
        }
    }
}
