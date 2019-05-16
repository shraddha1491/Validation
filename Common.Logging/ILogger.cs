using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// Emit an verbose to log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        void Verbose(string message, IDictionary<string, string> properties = null);

        void Information(string message, IDictionary<string, string> properties = null);

        void Warning(string message, IDictionary<string, string> properties = null);

        void Error(string message, IDictionary<string, string> properties = null);

        void Exception(Exception exception, IDictionary<string, string> properties = null);

        void Event(string eventName, IDictionary<string, string> properties, IDictionary<string, double> metrics = null);

        void Dependency(string dependecyName, string commandName, DateTimeOffset startTime, TimeSpan duration, bool success);
        void Request(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success);
    }
}
