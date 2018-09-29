using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Azure.WebJobs.Host;

namespace Ninject.AzureFunctions.Tests.Utility
{
    public class FakeTraceWriter : TraceWriter
    {
        public IList<TraceEvent> Log { get; set; } = new List<TraceEvent>();
        public FakeTraceWriter(TraceLevel level) : base(level)
        {
        }

        public override void Trace(TraceEvent traceEvent)
        {
            Log.Add(traceEvent);
        }
    }
}
