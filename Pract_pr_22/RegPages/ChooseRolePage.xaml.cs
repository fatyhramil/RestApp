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
    /// Логика взаимодействия для ChooseRolePage.xaml
    /// </summary>
    public partial class ChooseRolePage : Page
    {
        public ChooseRolePage()
        {
            InitializeComponent();
        }

        private void Radiobtn_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            User user = new User();

            if (radioButton.Name == "BookingRb")
            {
                user.RoleID = 1;
            }
            else
            {
                user.RoleID = 2;
            }

            NavigationService.Navigate(new RegPage(user));
        }
    }
}
