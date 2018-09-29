﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Ninject.AzureFunctions.Tests.Utility
{
    public class FakeLogger : ILogger
    {
        public IList<EventId> Log { get; set; } = new List<EventId>();
        public FakeLogger()
        {
        }

        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Log.Add(eventId);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }
    }
}
