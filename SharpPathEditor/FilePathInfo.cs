using System;

namespace SharpPathEditor
{
    internal class FilePathInfo
    {
        public static string AppPath => typeof(App).Assembly.Location;

        public static string AppLocation => AppDomain.CurrentDomain.BaseDirectory;

        public static string MainWindowSettings => $"{AppLocation}\\MainWindowSettings.xml";
    }
}
