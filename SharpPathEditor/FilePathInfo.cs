using System.IO;

namespace SharpPathEditor
{
    internal class FilePathInfo
    {
        public static string AppPath => typeof(App).Assembly.Location;

        public static string AppLocation => Path.GetDirectoryName(AppPath);

        public static string MainWindowSettings => $"{AppLocation}\\MainWindowSettings.xml";
    }
}
