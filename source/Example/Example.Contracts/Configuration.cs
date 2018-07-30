using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Contracts
{
    public class Configuration
    {
        public string ConnectionString { get; set; }

        public Configuration()
        {
            ConnectionString = Environment.GetEnvironmentVariable("connectionString");
        }
    }
}
