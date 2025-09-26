using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Services.Analytics
{
    public class AnalyticEvent : IAnalyticEvent
    {
        private readonly string _key;
        private readonly Dictionary<string, object> _parameters;

        public bool IsHaveParameters => _parameters.Count > 0;
        public string GetKey() => _key;

        private AnalyticEvent(string eventName)
        {
            _key = eventName;
            _parameters = new Dictionary<string, object>();
        }

        public static AnalyticEvent Create(string eventName) =>
            new(eventName);

        public AnalyticEvent WithParameters(params (string key, object value)[] parameters)
        {
            foreach (var parameter in parameters)
                _parameters.Add(parameter.key, parameter.value);

            return this;
        }

        public Dictionary<string, object> GetParameters() =>
            _parameters;

        public Dictionary<string, string> GetStringParameters() =>
            _parameters.ToDictionary(pair => pair.Key, pair => pair.Value.ToString());
    }
}
