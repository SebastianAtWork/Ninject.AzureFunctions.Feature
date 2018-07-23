using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Repositories
{
    public class ExampleRepository
    {
        private readonly string _connectionString;

        public ExampleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
