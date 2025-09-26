using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace StripedArts.Unity.Logging.Core.UnityBuild
{
    [InitializeOnLoad]
    public class LoggerPostProcess : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; }

        static LoggerPostProcess() => SetTraceLogType();

        public void OnPreprocessBuild(BuildReport report) => SetTraceLogType();

        private static void SetTraceLogType()
        {
            PlayerSettings.SetStackTraceLogType(LogType.Error, StackTraceLogType.ScriptOnly);
            PlayerSettings.SetStackTraceLogType(LogType.Exception, StackTraceLogType.ScriptOnly);
        }
    }
}
