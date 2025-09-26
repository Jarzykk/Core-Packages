using System;
using System.Collections.Generic;
using Infrastructure.Services.Analytics.Data;
using System.Linq;
using StripedArts.Unity.Core.Logging.Core;
using StripedArts.Unity.Core.Logging.Core.Channels;
using StripedArts.Unity.Core.Logging.Core.Factory;
using StripedArts.Unity.Core.Logging.Core.Interfaces;
using UnityEngine;

namespace Infrastructure.Services.Analytics
{
    public class AnalyticService : IAnalyticService
    {
        private readonly ILogProvider _logProvider = LogFactory.Produce<AnalyticService>(DSenders.Analytics);

        private readonly ISimulatedAnalyticsProvider _simulatedAnalyticsProvider = new SimulatedAnalyticsProvider();

        private readonly Dictionary<AnalyticSource, IAnalyticProvider> _providers;

        public AnalyticService(IEnumerable<IAnalyticProvider> providers) =>
            _providers = providers.ToDictionary(provider => provider.Source);

        public void SendEvent(IAnalyticEvent analyticEvent) =>
            SendEvent(analyticEvent, AnalyticsChannels.General);

        public void SendEvent(IAnalyticEvent analyticEvent, params AnalyticSource[] analyticSource)
        {
            if (analyticSource is null)
                throw new ArgumentException("{0} AnalyticSource is empty", analyticEvent.GetKey());

            if (analyticSource.Contains(AnalyticSource.None))
                throw new ArgumentException("{0} AnalyticSource [None] is not allowed", analyticEvent.GetKey());

            TrackProviders(analyticEvent, analyticSource);

#if DUBUG || UNITY_EDITOR
            SendDebugEvent(analyticEvent, analyticSource);
#endif
        }

        private void TrackProviders(IAnalyticEvent analyticEvent, AnalyticSource[] analyticSource)
        {
            var selectedProviders = GetProviders(analyticSource);

            foreach (var provider in selectedProviders)
                TrackEvent(provider, analyticEvent);
        }

        private void TrackEvent(IAnalyticProvider eventProvider, IAnalyticEvent analyticEvent)
        {
            try
            {
                eventProvider.SendEvent(analyticEvent);
            }
            catch (Exception e)
            {
                _logProvider.LogError($"Error while sending event to {eventProvider.Source}: {e.Message}");
            }
        }

        private void SendDebugEvent(IAnalyticEvent analyticEvent, AnalyticSource[] analyticSource)
        {
            if (_simulatedAnalyticsProvider is not null)
                _simulatedAnalyticsProvider.SendEvent(analyticEvent, analyticSource);
            else
                _logProvider.LogError("SimulatedAnalyticsProvider not found");
        }

        private IEnumerable<IAnalyticProvider> GetProviders(AnalyticSource[] analyticSource)
        {
            if (analyticSource.Contains(AnalyticSource.All))
                return _providers.Values;

            if (Application.isEditor)
                ValidateProvidersLog(analyticSource);

            return _providers
                .Keys
                .Intersect(analyticSource)
                .Select(x => _providers[x]);
        }

        private void ValidateProvidersLog(AnalyticSource[] analyticSource)
        {
            foreach (var source in analyticSource)
                if (!_providers.ContainsKey(source))
                    _logProvider.LogWarning($"Provider for {source} not found");
        }
    }
}
