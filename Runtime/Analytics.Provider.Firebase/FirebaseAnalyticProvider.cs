using Firebase.Analytics;
using Infrastructure.Services.Analytics;
using Infrastructure.Services.Analytics.Data;
using StripedArts.Analytics.Provider.Firebase.Extension;

namespace StripedArts.Analytics.Provider.Firebase
{
    public class FirebaseAnalyticProvider : IAnalyticProvider
    {
        public AnalyticSource Source => AnalyticSource.Firebase;

        public void SendEvent(IAnalyticEvent analyticEvent)
        {
            if (analyticEvent.IsHaveParameters)
                SendWithParameters(analyticEvent);
            else
                FirebaseAnalytics.LogEvent(analyticEvent.GetKey());
        }

        private void SendWithParameters(IAnalyticEvent analyticEvent)
        {
            var eventParams = analyticEvent.GetParameters();
            var parameters = eventParams.ToFirebaseParameters();

            FirebaseAnalytics.LogEvent(analyticEvent.GetKey(), parameters);
        }
    }
}
