using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

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
