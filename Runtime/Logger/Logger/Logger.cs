using System;
using System.Globalization;
using System.Text;
using StripedArts.Unity.Core.Logging.Core.Enums;
using StripedArts.Unity.Core.Logging.Core.Extensions;
using StripedArts.Unity.Core.Logging.Core.Interfaces;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace StripedArts.Unity.Core.Logging.Core.Logger
{
    public static class Logger
    {
        private static readonly UnityEngine.Logger ULogger = new(Debug.unityLogger.logHandler);

        public static ILogProvider CreateFor(Type type, DChannel tag = null) =>
            new PLogger(type, tag);

        public static ILogProvider CreateFor<T>(DChannel tag = null) =>
            new PLogger(typeof(T), tag);

        [HideInCallstack]
        public static void Log(LogLevel logLevel, Type source, string tag, object param)
        {
            var convertible = param as IConvertible;
            LogMessage(logLevel, source, tag, (convertible == null ? param.ToString() : convertible?.ToString(CultureInfo.InvariantCulture)));
        }

        [HideInCallstack]
        public static void Log(LogLevel logLevel, Type source, string tag, Func<string> method)
        {
            var message = method.Invoke();
            LogMessage(logLevel, source, tag, string.Format(CultureInfo.InvariantCulture, "{0}", message));
        }

        [HideInCallstack]
        public static void Log<T1>(LogLevel logLevel, Type source, string tag, T1 message) =>
            LogMessage(logLevel, source, tag, string.Format(CultureInfo.InvariantCulture, "{0}", message));

        [HideInCallstack]
        public static void Log<T1>(LogLevel logLevel, Type source, string tag, string format, T1 message) =>
            LogMessage(logLevel, source, tag, string.Format(CultureInfo.InvariantCulture, format, message));

        [HideInCallstack]
        public static void Log<T1, T2>(LogLevel logLevel, Type source, string tag, string format, T1 arg1, T2 arg2) =>
            LogMessage(logLevel, source, tag, string.Format(CultureInfo.InvariantCulture, format, arg1, arg2));

        [HideInCallstack]
        public static void Log<T1, T2, T3>(LogLevel logLevel, Type source, string tag, string format, T1 arg1, T2 arg2, T3 arg3) =>
            LogMessage(logLevel, source, tag, string.Format(CultureInfo.InvariantCulture, format, arg1, arg2, arg3));

        [HideInCallstack]
        public static void Log(LogLevel logLevel, Type source, string tag, string format, params object[] param) =>
            LogMessage(logLevel, source, tag, param.Length > 0 ? string.Format(CultureInfo.InvariantCulture, format, param) : format);

        [HideInCallstack]
        public static void Log<T>(LogLevel logLevel, Type source, string tag, T message, Exception exception = null) =>
            LogMessage(logLevel, source, tag, string.Format(CultureInfo.InvariantCulture, "{0}", message), exception);

        [HideInCallstack]
        public static void Log(LogLevel logLevel, Type source, string tag, string format, Exception exception, params object[] param) =>
            LogMessage(logLevel, source, tag, param.Length > 0 ? string.Format(CultureInfo.InvariantCulture, format, param) : format, exception);

        [HideInCallstack]
        private static void LogMessage(LogLevel logLevel, Type source, string tag, string message, Exception exception = null)
        {
            var logMessage = new StringBuilder();

            if (!string.IsNullOrEmpty(tag))
                logMessage.AppendFormat("{0}: ", tag);

            logMessage.AppendFormat("{0} - ", source.Name.Bold());

            logMessage.Append(message);

            if (exception != null)
                logMessage.AppendLine(exception?.ToLogString());

            ULogger.Log(logLevel.ToUnity(), logMessage.ToString());
        }
    }
}
