using System;
using System.Collections.Generic;

namespace Common.Logging
{
    /// <summary>
    /// Send events, metrics and other telemetry to the Console
    /// Use it in UnitTesting
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Verbose(string message, IDictionary<string, string> properties = null)
        {
            Log(message);
        }

        public void Information(string message, IDictionary<string, string> properties = null)
        {
            Log(message);
        }

        public void Warning(string message, IDictionary<string, string> properties = null)
        {
            Log(message);
        }

        public void Error(string message, IDictionary<string, string> properties = null)
        {
            Log(message);
        }

        public void Exception(Exception exception, IDictionary<string, string> properties = null)
        {
            Log(exception.ToString());
        }

        public void Event(string eventName, IDictionary<string, string> properties, IDictionary<string, double> metrics = null)
        {
            Log(eventName);
        }

        public void Dependency(string dependecyName, string commandName, DateTimeOffset startTime, TimeSpan duration, bool success)
        {
            Log(dependecyName);
        }

        public void Request(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
        {
            Log(name);
        }
    }
}
