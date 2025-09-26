using Infrastructure.Services.Analytics.Data;

namespace Infrastructure.Services.Analytics
{
    public interface ISimulatedAnalyticsProvider
    {
        void SendEvent(IAnalyticEvent analyticEvent, AnalyticSource[] sources);
    }
}