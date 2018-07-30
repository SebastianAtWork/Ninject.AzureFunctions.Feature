using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Contracts;
using Example.Contracts.Repositories;

namespace Example.Repositories
{
    public class ExampleRepository : IExampleRepository
    {

        public ExampleRepository(Configuration configuration)
        {
        }
    }
}
