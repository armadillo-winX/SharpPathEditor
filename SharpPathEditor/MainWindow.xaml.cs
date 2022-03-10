using System;
using System.Linq;
using System.Windows;

namespace SharpPathEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _appName = VerInfo.AppName;

        private AboutDialog _aboutDialog = null;

        public MainWindow()
        {
            InitializeComponent();

            this.Title = _appName;
            GetPathList();
        }

        private void GetPathList()
        {
            SystemPathListBox.Items.Clear();
            CurrentUserPathListBox.Items.Clear();
            try
            {
                string[] systemPathList = EditPath.GetSystemPathList();
                if (systemPathList != null)
                {
                    foreach (string systemPath in systemPathList)
                    {
                        if(systemPath != "")
                        {
                            SystemPathListBox.Items.Add(systemPath);
                        }

                    }
                }

                string[] currentUserPathList = EditPath.GetCurrentUserPathList();
                if (currentUserPathList != null)
                {
                    foreach (string currentUserPath in currentUserPathList)
                    {
                        if(currentUserPath != "")
                        {
                            CurrentUserPathListBox.Items.Add(currentUserPath);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "エラー",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveSystemPath()
        {
            string[] systemPathList = SystemPathListBox.Items.Cast<string>().ToArray();
            try
            {
                EditPath.SaveSystemPath(systemPathList);
                _ = MessageBox.Show(this, "保存しました。", _appName,
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "エラー",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveCurrentUserPath()
        {
            string[] currentUserPathList = CurrentUserPathListBox.Items.Cast<string>().ToArray();
            try
            {
                EditPath.SaveCurrentUserPath(currentUserPathList);
                _ = MessageBox.Show(this, "保存しました。", _appName,
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "エラー",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewSystemPathButton_Click(object sender, RoutedEventArgs e)
        {
            NewPathDialog newPathDialog = new();
            newPathDialog.Owner = this;
            if (newPathDialog.ShowDialog() == true)
            {
                string path = newPathDialog.Path;
                SystemPathListBox.Items.Add(path);
            }
        }

        private void DeleteSystemPathButton_Click(object sender, RoutedEventArgs e)
        {
            if (SystemPathListBox.SelectedIndex > -1)
            {
                MessageBoxResult result = MessageBox.Show(
                    this, $"'{SystemPathListBox.SelectedItem}' を削除しますか?", "削除の確認",
                    MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    SystemPathListBox.Items.Remove(SystemPathListBox.SelectedItem);
                }
            }
        }

        private void SaveSystemPathMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveSystemPath();
        }

        private void NewCurrentUserPathButton_Click(object sender, RoutedEventArgs e)
        {
            NewPathDialog newPathDialog = new();
            newPathDialog.Owner = this;
            if (newPathDialog.ShowDialog() == true)
            {
                string path = newPathDialog.Path;
                CurrentUserPathListBox.Items.Add(path);
            }
        }

        private void DeleteCurrentUserPathButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUserPathListBox.SelectedIndex > -1)
            {
                MessageBoxResult result = MessageBox.Show(
                    this, $"'{CurrentUserPathListBox.SelectedItem}' を削除しますか?", "削除の確認",
                    MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    CurrentUserPathListBox.Items.Remove(CurrentUserPathListBox.SelectedItem);
                }
            }
        }

        private void SaveCurrentUserPathMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveCurrentUserPath();
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_aboutDialog == null || !_aboutDialog.IsLoaded)
            {
                _aboutDialog = new();
                _aboutDialog.Owner = this;
                _aboutDialog.Show();
            }
            else
            {
                _aboutDialog.WindowState = WindowState.Normal;
                _ = _aboutDialog.Activate();
            }
        }

        private void ReloadPathMenuItem_Click(object sender, RoutedEventArgs e)
        {
            GetPathList();
        }

        private void ChangeSystemPathButton_Click(object sender, RoutedEventArgs e)
        {
            if (SystemPathListBox.SelectedIndex != -1)
            {
                NewPathDialog newPathDialog = new();
                newPathDialog.OldPath = SystemPathListBox.SelectedValue.ToString();
                newPathDialog.Owner = this;
                if (newPathDialog.ShowDialog() == true)
                {
                    string path = newPathDialog.Path;

                    SystemPathListBox.Items[SystemPathListBox.SelectedIndex] = path;
                }
            }
            else
            {
                _ = MessageBox.Show(this, "PATHを選んでください", "Path 編集",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
        private void UpSystemPathButton_Click(object sender, RoutedEventArgs e)
        {
            int index = SystemPathListBox.SelectedIndex;
            if (index >= 1)
            {

                string temp_path = SystemPathListBox.SelectedValue.ToString();
                SystemPathListBox.Items[index] = SystemPathListBox.Items[SystemPathListBox.SelectedIndex - 1].ToString();
                SystemPathListBox.Items[index - 1] = temp_path;

                SystemPathListBox.SelectedIndex = index - 1;
            }
        }
        private void DownSystemPathButton_Click(object sender, RoutedEventArgs e)
        {
            int index = SystemPathListBox.SelectedIndex;
            if (index != -1 && index != SystemPathListBox.Items.Count - 1)
            {

                string temp_path = SystemPathListBox.SelectedValue.ToString();
                SystemPathListBox.Items[index] = SystemPathListBox.Items[SystemPathListBox.SelectedIndex + 1].ToString();
                SystemPathListBox.Items[index + 1] = temp_path;

                SystemPathListBox.SelectedIndex = index + 1;
            }
        }

        private void ChangeCurrentUserPathButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUserPathListBox.SelectedIndex != -1)
            {
                NewPathDialog newPathDialog = new();
                newPathDialog.OldPath = CurrentUserPathListBox.SelectedValue.ToString();
                newPathDialog.Owner = this;
                if (newPathDialog.ShowDialog() == true)
                {
                    string path = newPathDialog.Path;

                    CurrentUserPathListBox.Items[CurrentUserPathListBox.SelectedIndex] = path;
                }
            }
            else
            {
                _ = MessageBox.Show(this, "PATHを選んでください", "Path 編集",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void UpCurrentUserPathButton_Click(object sender, RoutedEventArgs e)
        {
            int index = CurrentUserPathListBox.SelectedIndex;
            if (index >= 1)
            {

                string temp_path = CurrentUserPathListBox.SelectedValue.ToString();
                CurrentUserPathListBox.Items[index] = CurrentUserPathListBox.Items[CurrentUserPathListBox.SelectedIndex - 1].ToString();
                CurrentUserPathListBox.Items[index - 1] = temp_path;

                CurrentUserPathListBox.SelectedIndex = index - 1;
            }
        }

        private void DownCurrentUserPathButton_Click(object sender, RoutedEventArgs e)
        {
            int index = CurrentUserPathListBox.SelectedIndex;
            if (index != -1 && index != CurrentUserPathListBox.Items.Count - 1)
            {

                string currentPath = CurrentUserPathListBox.SelectedValue.ToString();
                CurrentUserPathListBox.Items[index] = CurrentUserPathListBox.Items[CurrentUserPathListBox.SelectedIndex + 1].ToString();
                CurrentUserPathListBox.Items[index + 1] = currentPath;

                CurrentUserPathListBox.SelectedIndex = index + 1;
            }
        }
    }
}
