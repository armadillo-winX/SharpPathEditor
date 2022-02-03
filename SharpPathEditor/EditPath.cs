using Microsoft.Win32;

namespace SharpPathEditor
{
    internal class EditPath
    {
        private static readonly string _systemPathRegKey = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment";
        private static readonly string _currentUserPathRegKey = "Environment";

        public static void SaveSystemPath(string[] systemPathList)
        {
            string data = string.Join(";", systemPathList);

            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(_systemPathRegKey);
            registryKey.SetValue("Path", data);
            registryKey.Close();
        }

        public static void SaveCurrentUserPath(string[] currentUserPathList)
        {
            string data = string.Join(";", currentUserPathList);

            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(_currentUserPathRegKey);
            registryKey.SetValue("Path", data);
            registryKey.Close();
        }

        public static string[] GetSystemPathList()
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(_systemPathRegKey, false);

            if (registryKey != null)
            {
                string data = (string)registryKey.GetValue("Path");
                registryKey.Close();

                return data.Split(';');
            }
            else
            {
                return null;
            }
        }

        public static string[] GetCurrentUserPathList()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(_currentUserPathRegKey, false);

            if (registryKey != null)
            {
                string data = (string)registryKey.GetValue("Path");
                registryKey.Close();

                return data.Split(';');
            }
            else
            {
                return null;
            }
        }
    }
}
