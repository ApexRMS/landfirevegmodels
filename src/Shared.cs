using System;
using System.Globalization;
using System.Windows.Forms;

namespace LandFireVegModels
{
    internal static class Shared
    {
        private const string MSGBOX_TITLE = "Landfire Vegetation Models";

        internal static DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, params object[] args)
        {
            return ShowMessageBox(
                String.Format(CultureInfo.InvariantCulture, text, args),
                buttons);
        }

        internal static DialogResult ShowMessageBox(string text, MessageBoxButtons buttons)
        {
            return MessageBox.Show(
                text,
                MSGBOX_TITLE,
                buttons,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                (MessageBoxOptions)0);
        }
    }
}
