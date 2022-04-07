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
using System.Web.Security;
using System.Text.RegularExpressions;
using Pract_pr_22.RolePages;

namespace Pract_pr_22.RegPages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        private static User localuser;
        public RegPage(User user)
        {
            InitializeComponent();

            localuser = user;

            if (localuser.IDRole == 1)
            {
                NeedForLbl.Content += "управления ресторанами";
            }
            else
            {
                NeedForLbl.Content += "бронирования столиков";
            }
        }

        private void CreatePassCb_Checked(object sender, RoutedEventArgs e)
        {
            PasswordTb.Text = Membership.GeneratePassword(8, 2);
        }

        private void Enterbtn_Click(object sender, RoutedEventArgs e)
        {
            if (GetRegBool())
            {
                localuser.Phone = PhoneTb.Text;
                localuser.Name = NameTb.Text;
                localuser.Password = PasswordTb.Text;

                MainWindow.ent.User.Add(localuser);
                MainWindow.ent.SaveChanges();

                if (localuser.IDRole == 1)
                {
                    NavigationService.Navigate(new ClientPage(localuser));
                }
                else
                {
                    NavigationService.Navigate(new CreatorPage(localuser));
                }
            }
        }

        private bool GetRegBool()
        {
            if ((MainWindow.ent.User.ToList().Find(c => c.Phone == PhoneTb.Text && c.Password == PasswordTb.Text)) != null)
            {
                MessageBox.Show("Пароль не подходит");
                return false;
            }

            if (!(bool)IsAgreeCb.IsChecked)
            {
                return false;
            }

            if (PasswordTb.Text.Length < 8)
            {
                PasswordTb.BorderBrush = Brushes.Red;

                MessageBox.Show("Длинна пароля должна быть от 8 символов");

                return false;
            }

            if (string.IsNullOrEmpty(NameTb.Text))
            {
                NameTb.BorderBrush = Brushes.Red;

                return false;
            }

            if (!Regex.Match(PhoneTb.Text, @"^((\+7|7|8)+([0-9]){10})$").Success)
            {
                PhoneTb.BorderBrush = Brushes.Red;

                return false;
            }

            return true;
        }
    }
}
