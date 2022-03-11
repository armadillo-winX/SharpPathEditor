using System.IO;
using System.Xml.Serialization;

namespace SharpPathEditor
{
    public class MainWindowSettings
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public bool IsMaximize { get; set; }

        public int SelectedTabIndex { get; set; }

        public static void SaveMainWindowSettings(MainWindowSettings mainWindowSettings)
        {
            string? mainWindowSettingsFile = PathInfo.MainWindowSettings;

            XmlSerializer mainWindowSettingsSerializer = new(typeof(MainWindowSettings));
            FileStream fs = new(mainWindowSettingsFile, FileMode.Create);
            mainWindowSettingsSerializer.Serialize(fs, mainWindowSettings);
            fs.Close();
        }

        public static MainWindowSettings ConfigureMainWindowSettings()
        {
            string? mainWindowSettingsFile = PathInfo.MainWindowSettings;

            MainWindowSettings mainWindowSettings = new();
            if (File.Exists(mainWindowSettingsFile))
            {
                XmlSerializer mainWindowSettingsSerializer = new(typeof(MainWindowSettings));
                FileStream fs = new(mainWindowSettingsFile, FileMode.Open);

                mainWindowSettings = (MainWindowSettings)mainWindowSettingsSerializer.Deserialize(fs);
                fs.Close();
            }
            else
            {
                mainWindowSettings.Width = 600;
                mainWindowSettings.Height = 385;
                mainWindowSettings.IsMaximize = false;
                mainWindowSettings.SelectedTabIndex = 0;
            }
            return mainWindowSettings;
        }
    }
}
