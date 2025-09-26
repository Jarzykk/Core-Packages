using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.Analytics;

namespace StripedArts.Analytics.Provider.Firebase.Extension
{
    public static class FirebaseParameterExtensions
    {
        public static Parameter[] ToFirebaseParameters(this Dictionary<string, object> parameters)
        {
            return parameters.Select(parameter =>
            {
                var key = parameter.Key;
                var value = parameter.Value;

                return value switch
                {
                    string stringValue => new Parameter(key, stringValue),
                    long longValue => new Parameter(key, longValue),
                    double doubleValue => new Parameter(key, doubleValue),
                    bool boolValue => new Parameter(key, boolValue.ToString()),
                    int intValue => new Parameter(key, intValue),
                    float floatValue => new Parameter(key, floatValue),
                    DateTime dateTimeValue => new Parameter(key, dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss")),
                    null => new Parameter(key, string.Empty),
                    IDictionary<string, object> dictionaryValue => new Parameter(key, dictionaryValue),
                    IEnumerable<IDictionary<string, object>> enumerableValue => new Parameter(key, enumerableValue),
                    _ => throw new ArgumentException($"Unsupported parameter type for key {key}: {value.GetType()}")
                };
            }).ToArray();
        }
    }
}
