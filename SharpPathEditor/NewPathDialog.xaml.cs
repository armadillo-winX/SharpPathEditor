using System.Windows;

namespace SharpPathEditor
{
    /// <summary>
    /// NewPathDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class NewPathDialog : Window
    {
        public string Path { get; set; }

#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        public NewPathDialog()
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ = PathTextBox.Focus();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            string path = PathTextBox.Text;
            if (!string.IsNullOrEmpty(path))
            {
                this.Path = path;
                DialogResult = true;
            }
            else
            {
                _ = MessageBox.Show(this, "値がセットされていません。", "Path 新規追加ダイアログ",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
                _ = PathTextBox.Focus();
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new();
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathTextBox.Text = folderBrowserDialog.SelectedPath;
            }

        }
    }
}
