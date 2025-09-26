using Infrastructure.Services.Analytics.Data;

namespace Infrastructure.Services.Analytics
{
    public interface IAnalyticService
    {
        void SendEvent(IAnalyticEvent analyticEvent);
        void SendEvent(IAnalyticEvent analyticEvent, params AnalyticSource[] analyticSource);
    }
}
