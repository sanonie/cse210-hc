using System;
using System.IO;

namespace Mindfulness
{
    public static class ActivityLogger
    {
        private static string _path = "mindfulness_log.txt";

        public static void Log(string activityName)
        {
            try
            {
                var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\t{activityName}";
                File.AppendAllLines(_path, new[] { line });
            }
            catch
            {
                // don't crash if logging fails
            }
        }

        public static string[] ReadLog()
        {
            try
            {
                if (File.Exists(_path))
                {
                    return File.ReadAllLines(_path);
                }
            }
            catch
            {
                // ignore read errors
            }
            return Array.Empty<string>();
        }
    }
}
