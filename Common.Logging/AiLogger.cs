using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace Common.Logging
{
    /// <summary>
    /// Send events, metrics and other telemetry to the Application Insights service.
    /// </summary>
    public class AiLogger : ILogger
    {
        private readonly TelemetryClient client;

        /// <summary>
        /// Default constructor for AiLogger where InstrumentationKey is picked up from ApplicationInsights.Config
        /// </summary>
        public AiLogger()
        {
            client = new TelemetryClient();
        }

        /// <summary>
        /// In case a separate client for manual logs is required. The default logging (automatic logs like Requests, Dependencies) will still use the InstrumentationKey from ApplicationInsights.Config
        /// </summary>
        /// <param name="client"></param>
        public AiLogger(TelemetryClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Specify a separate client for manual logs. The default logging (automatic logs like Requests, Dependencies) will still use the InstrumentationKey from ApplicationInsights.Config
        /// </summary>
        /// <param name="instrumentationKey"></param>
        public AiLogger(string instrumentationKey)
        {
            this.client = new TelemetryClient();
            client.InstrumentationKey = instrumentationKey;
        }
        private void TrackTrace(string message, SeverityLevel sevLevel, IDictionary<string, string> properties)
        {
            client.TrackTrace(message, sevLevel, properties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>
        public void Information(string message, IDictionary<string, string> properties = null)
        {
            TrackTrace(message, SeverityLevel.Information, properties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>

        public void Warning(string message, IDictionary<string, string> properties = null)
        {
            TrackTrace(message, SeverityLevel.Warning, properties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>

        public void Error(string message, IDictionary<string, string> properties = null)
        {
            TrackTrace(message, SeverityLevel.Error, properties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="properties">Named string values you can use to classify and search for this exception.</param>
        public void Exception(Exception exception, IDictionary<string, string> properties = null)
        {
            client.TrackException(exception, properties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="properties">Named string values you can use to search and classify events.</param>
        /// <param name="metrics"></param>
        public void Event(string eventName, IDictionary<string, string> properties, IDictionary<string, double> metrics = null)
        {
            client.TrackEvent(eventName, properties, metrics);
        }

        /// <summary>
        /// Send information about external dependency call in the application.
        /// </summary>
        /// <param name="dependecyName">External dependency name.</param>
        /// <param name="commandName">Dependency call command name.</param>
        /// <param name="startTime">The time when the dependency was called.</param>
        /// <param name="duration">The time taken by the external dependency to handle the call.</param>
        /// <param name="success">True if the dependency call was handled successfully.</param>
        public void Dependency(string dependecyName, string commandName, DateTimeOffset startTime, TimeSpan duration, bool success)
        {
            client.TrackDependency(dependecyName, commandName, startTime, duration, success);
        }

        /// <summary>
        /// Use it default AiLogging Module is not switched at api level
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startTime"></param>
        /// <param name="duration"></param>
        /// <param name="responseCode"></param>
        /// <param name="success"></param>
        public void Request(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
        {
            client.TrackRequest(name, startTime, duration, responseCode, success);
        }

        public void Verbose(string message, IDictionary<string, string> properties = null)
        {
            throw new NotImplementedException();
        }
    }
}
