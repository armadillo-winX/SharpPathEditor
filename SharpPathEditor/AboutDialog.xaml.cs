using System.Windows;

namespace SharpPathEditor
{
    /// <summary>
    /// AboutDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class AboutDialog : Window
    {
        public AboutDialog()
        {
            InitializeComponent();

            AppNameTextBlock.Text = VerInfo.AppName;
            VersionTextBlock.Text = $"Version {VerInfo.AppVersion}";
            DeveloperTextBlock.Text = $"Developer: {VerInfo.Developer}";
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
