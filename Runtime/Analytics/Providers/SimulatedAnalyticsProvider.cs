using System.Text;
using Infrastructure.Services.Analytics.Data;
using StripedArts.Unity.Core.Logging.Core;
using StripedArts.Unity.Core.Logging.Core.Factory;
using StripedArts.Unity.Core.Logging.Core.Interfaces;

namespace Infrastructure.Services.Analytics
{
    public class SimulatedAnalyticsProvider : ISimulatedAnalyticsProvider
    {
        private readonly ILogProvider _logProvider = LogFactory.Produce<SimulatedAnalyticsProvider>(DSenders.Analytics);

        public AnalyticSource Source => AnalyticSource.Simulated;

        public void SendEvent(IAnalyticEvent analyticEvent, AnalyticSource[] sources)
        {
            StringBuilder eventLog = new StringBuilder();

            eventLog.AppendLine($"Simulated Analytics Event: {analyticEvent.GetKey()}");
            eventLog.AppendLine($"Sources for event: {string.Join(", ", sources)}");
            eventLog.AppendLine($"Params: {string.Join(", ", analyticEvent.GetParameters())}");

            _logProvider.LogInfo(eventLog.ToString());
        }
    }
}
