using Infrastructure.Services.Analytics.Data;

namespace Infrastructure.Services.Analytics
{
    public interface IAnalyticProvider
    {
        AnalyticSource Source { get; }
        void SendEvent(IAnalyticEvent analyticEvent);
    }
}
