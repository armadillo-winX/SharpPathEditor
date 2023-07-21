using System;
using System.Diagnostics;

namespace SharpPathEditor
{
    class ApplicationLauncher
    {
        public static void LaunchCommandPrompt()
        {
            string cmdPath = Environment.GetEnvironmentVariable("ComSpec");
            string systemDirectory = Environment.SystemDirectory;

            ProcessStartInfo processStartInfo = new();
            processStartInfo.FileName = cmdPath;
            processStartInfo.WorkingDirectory = systemDirectory;
            processStartInfo.Verb = "runas";
            processStartInfo.UseShellExecute = true;

            _ = Process.Start(processStartInfo);
        }

        public static void LaunchRegstryEditor()
        {
            string windowsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows);

            ProcessStartInfo processStartInfo = new();
            processStartInfo.FileName = $"{windowsDirectory}\\regedit.exe";
            processStartInfo.WorkingDirectory = windowsDirectory;
            processStartInfo.Verb = "runas";
            processStartInfo.UseShellExecute = true;

            _ = Process.Start(processStartInfo);
        }
    }
}
