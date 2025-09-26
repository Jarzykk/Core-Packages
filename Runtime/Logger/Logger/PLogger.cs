using System;
using StripedArts.Unity.Core.Logging.Core.Enums;
using StripedArts.Unity.Core.Logging.Core.Interfaces;
using UnityEngine;
using static StripedArts.Unity.Core.Logging.Core.Logger.Logger;

namespace StripedArts.Unity.Core.Logging.Core.Logger
{
    internal class PLogger : ILogProvider
    {
        private readonly Type _sourceType;
        private readonly string _tag;

        internal PLogger(Type type, DChannel tag = null)
        {
            _sourceType = type;
            _tag = tag == null ? string.Empty : tag.Name;
        }

        [HideInCallstack] public void LogDebug<T>(T message) => Log(LogLevel.Debug, _sourceType, _tag, message);

        [HideInCallstack] public void LogDebug<T1>(string format, T1 arg1) =>  Log(LogLevel.Debug, _sourceType, _tag, format, arg1);
        [HideInCallstack] public void LogDebug<T1, T2>(string format, T1 arg1, T2 arg2) => Log(LogLevel.Debug, _sourceType, _tag, format, arg1, arg2);
        [HideInCallstack] public void LogDebug<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3) => Log(LogLevel.Debug, _sourceType, _tag, format, arg1, arg2, arg3);
        [HideInCallstack] public void LogDebug(string format, params object[] arguments) => Log(LogLevel.Debug, _sourceType, _tag, format, arguments);
        [HideInCallstack] public void LogDebug(Func<string> method) => Log(LogLevel.Debug, _sourceType, _tag, method);

        [HideInCallstack] public void LogInfo<T>(T message) => Log(LogLevel.Info, _sourceType, _tag, message);
        [HideInCallstack] public void LogInfo<T1>(string format, T1 arg1) =>  Log(LogLevel.Info, _sourceType, _tag, format, arg1);
        [HideInCallstack] public void LogInfo<T1, T2>(string format, T1 arg1, T2 arg2) => Log(LogLevel.Info, _sourceType, _tag, format, arg1, arg2);
        [HideInCallstack] public void LogInfo<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3) => Log(LogLevel.Info, _sourceType, _tag, format, arg1, arg2, arg3);
        [HideInCallstack] public void LogInfo(string format, params object[] arguments) => Log(LogLevel.Info, _sourceType, _tag, format, arguments);
        [HideInCallstack] public void LogInfo(Func<string> method) => Log(LogLevel.Info, _sourceType, _tag, method);

        [HideInCallstack] public void LogWarning<T>(T message) => Log(LogLevel.Warning, _sourceType, _tag, message);
        [HideInCallstack] public void LogWarning<T1>(string format, T1 arg1) =>  Log(LogLevel.Warning, _sourceType, _tag, format, arg1);
        [HideInCallstack] public void LogWarning<T1, T2>(string format, T1 arg1, T2 arg2) => Log(LogLevel.Warning, _sourceType, _tag, format, arg1, arg2);
        [HideInCallstack] public void LogWarning<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3) => Log(LogLevel.Warning, _sourceType, _tag, format, arg1, arg2, arg3);
        [HideInCallstack] public void LogWarning(string format, params object[] arguments) => Log(LogLevel.Warning, _sourceType, _tag, format, arguments);
        [HideInCallstack] public void LogWarning(Func<string> method) => Log(LogLevel.Warning, _sourceType, _tag, method);

        [HideInCallstack] public void LogError<T>(T message) => Log(LogLevel.Error, _sourceType, _tag, message);
        [HideInCallstack] public void LogError<T1>(string format, T1 arg1) =>  Log(LogLevel.Error, _sourceType, _tag, format, arg1);
        [HideInCallstack] public void LogError<T1, T2>(string format, T1 arg1, T2 arg2) => Log(LogLevel.Error, _sourceType, _tag, format, arg1, arg2);
        [HideInCallstack] public void LogError<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3) => Log(LogLevel.Error, _sourceType, _tag, format, arg1, arg2, arg3);
        [HideInCallstack] public void LogError(string format, params object[] arguments) => Log(LogLevel.Error, _sourceType, _tag, format, arguments);
        [HideInCallstack] public void LogError<T>(Exception exception, T message) => Log(LogLevel.Error, _sourceType, _tag, message, exception);
        [HideInCallstack] public void LogError(Func<string> method) => Log(LogLevel.Error, _sourceType, _tag, method);

        [HideInCallstack] public void LogFormat(LogLevel logLevel, string format, Exception exception, params object[] arguments) => Log(logLevel, _sourceType, _tag, format, exception, arguments);
    }
}
