using System;
using System.Collections.Generic;
using NetScriptFramework.Tools;

namespace PluginTemplate
{
    public static class Utils
    {
        private static readonly LogFile LogFile;

        static Utils()
        {
            LogFile = new LogFile(Plugin.PluginName, LogFileFlags.AppendFile | LogFileFlags.AutoFlush);
        }

        public static void Log(string s)
        {
            LogFile.AppendLine(s);
        }

        public static void Do<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable) action(item);
        }
    }
}
