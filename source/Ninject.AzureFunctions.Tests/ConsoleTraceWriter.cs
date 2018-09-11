using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;

namespace Ninject.AzureFunctions.Tests
{
    public class ConsoleTraceWriter : TraceWriter
    {
        public ConsoleTraceWriter(TraceLevel level) : base(level)
        {
        }

        public override void Trace(TraceEvent traceEvent)
        {
            Console.WriteLine(traceEvent);
        }
    }
}
