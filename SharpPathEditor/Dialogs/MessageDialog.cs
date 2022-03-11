using System.Windows;

namespace SharpPathEditor.Dialogs
{
    internal class MessageDialog
    {
        public static void ShowErrorMessageDialog(string errorMessage, Window ownerWindow = null)
        {
            ErrorMessageDialog errorMessageDialog = new();
            errorMessageDialog.Message = errorMessage;
            if (ownerWindow != null)
                errorMessageDialog.Owner = ownerWindow;
            _ = errorMessageDialog.ShowDialog();
        }
    }
}
