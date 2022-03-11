using System.Windows;

namespace SharpPathEditor.Dialogs
{
    /// <summary>
    /// ErrorMessageDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class ErrorMessageDialog : Window
    {
        private string? _message;

        public string? Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
                MessageBlock.Text = value;
            }
        }

        public ErrorMessageDialog()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
