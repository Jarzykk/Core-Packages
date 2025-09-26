using System;
using StripedArts.Unity.Core.Logging.Core.Enums;
using UnityEngine;

namespace StripedArts.Unity.Core.Logging.Core.Interfaces
{
    public interface ILogProvider
    {
        [HideInCallstack] void LogDebug<T1>(string format, T1 arg1);
        [HideInCallstack] void LogDebug<T1, T2>(string format, T1 arg1, T2 arg2);

        [HideInCallstack] void LogDebug<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3);
        [HideInCallstack] void LogDebug(string format, params object[] arguments);
        [HideInCallstack] void LogDebug(Func<string> method);

        [HideInCallstack] void LogInfo<T>(T message);
        [HideInCallstack] void LogInfo<T1>(string format, T1 arg1);
        [HideInCallstack] void LogInfo<T1, T2>(string format, T1 arg1, T2 arg2);
        [HideInCallstack] void LogInfo<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3);
        [HideInCallstack] void LogInfo(string format, params object[] arguments);
        [HideInCallstack] void LogInfo(Func<string> method);

        [HideInCallstack] void LogWarning<T>(T message);
        [HideInCallstack] void LogWarning<T1>(string format, T1 arg1);
        [HideInCallstack] void LogWarning<T1, T2>(string format, T1 arg1, T2 arg2);
        [HideInCallstack] void LogWarning<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3);
        [HideInCallstack] void LogWarning(string format, params object[] arguments);
        [HideInCallstack] void LogWarning(Func<string> method);

        [HideInCallstack] void LogError<T>(T message);
        [HideInCallstack] void LogError<T1>(string format, T1 arg1);
        [HideInCallstack] void LogError<T1, T2>(string format, T1 arg1, T2 arg2);
        [HideInCallstack] void LogError<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3);
        [HideInCallstack] void LogError(string format, params object[] arguments);
        [HideInCallstack] void LogError<T>(Exception exception, T message);
        [HideInCallstack] void LogError(Func<string> method);

        [HideInCallstack] void LogFormat(LogLevel logLevel, string format, Exception exception, params object[] arguments);
    }
}
