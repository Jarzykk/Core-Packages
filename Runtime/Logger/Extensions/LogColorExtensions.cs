using StripedArts.Unity.Core.Logging.Core.Enums;
using UnityEngine;

namespace StripedArts.Unity.Core.Logging.Core
{
    public static class LogColorExtensions
    {
        public static LogType ToUnity(this LogLevel level)
        {
            return level switch {
                LogLevel.Debug => LogType.Log,
                LogLevel.Info => LogType.Log,
                LogLevel.Warning => LogType.Warning,
                LogLevel.Error => LogType.Error,
                _ => LogType.Log
            };
        }
    }
}
