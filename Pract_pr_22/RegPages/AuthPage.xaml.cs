using Pract_pr_22.RolePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pract_pr_22.RegPages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        //visibiliti cb pass

        public AuthPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChooseRolePage());
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = MainWindow.ent.User.ToList().Find(c => c.Phone == PhoneTb.Text && c.Password == PasswordTb.Password);

            if (user != null)
            {
                if (user.RoleID == 1)
                {
                    NavigationService.Navigate(new ClientPage(user));
                }
                else
                {
                    NavigationService.Navigate(new CreatorPage(user));
                }
            }
        }
    }
}
