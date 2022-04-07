using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pract_pr_22.CustomMessageWindows
{
    /// <summary>
    /// Логика взаимодействия для CustomMessageWindow.xaml
    /// </summary>
    public partial class CustomMessageWindow : Window
    {
        static CustomMessageWindow customMessageWindow;

        static DialogResult result = System.Windows.Forms.DialogResult.No;

        public CMessageTitle messageTitle { get; set; }

        public CustomMessageWindow()
        {
            InitializeComponent();
        }

        public enum CMessageButton
        {
            Ok,
            Yes,
            No,
            Cancel,
            Confirm
        }

        public string GetTitle(CMessageTitle value)
        {
            return Enum.GetName(typeof(CMessageTitle), value);
        }

        public string GetButtonText(CMessageButton value)
        {
            return Enum.GetName(typeof(CMessageButton), value);
        }

        public enum CMessageTitle
        {
            Error,
            Info,
            Warning,
            Confirm
        }

        public static DialogResult Show(string message, string contentYesBtn, string contentNoBtn)
        {
            customMessageWindow = new CustomMessageWindow();
            customMessageWindow.AcceptBtn.Content = contentYesBtn;
            customMessageWindow.BackBtn.Content = contentNoBtn;
            customMessageWindow.txtMessage.Text = message;

            customMessageWindow.ShowDialog();
            return result;
        }

        private void BntOk_Click(object sender, RoutedEventArgs e)
        {
            result = System.Windows.Forms.DialogResult.Yes;
            Border border = new Border();

            customMessageWindow.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            result = System.Windows.Forms.DialogResult.No;
            customMessageWindow.Close();
        }

        private void GrowAnimation_Completed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
