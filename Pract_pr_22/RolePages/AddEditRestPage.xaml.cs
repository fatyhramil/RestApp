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

namespace Pract_pr_22.RolePages
{
    /// <summary>
    /// Логика взаимодействия для AddEditRestPage.xaml
    /// </summary>
    public partial class AddEditRestPage : Page
    {
        Ownership localOwnership;
        Restaurant restaurant;
        public AddEditRestPage(Ownership ownership)
        {
            InitializeComponent();
            localOwnership = ownership;

            if (localOwnership != null)
            {
                restaurant = MainWindow.ent.Restaurant.Where(c => c.ID == localOwnership.RestaurantID).FirstOrDefault();
            }
            DataContext = restaurant;
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void YesRb_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NoRb_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddRestBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameTb.Text.Length > 0 && AboutTb.Text.Length > 0 && AddressTb.Text.Length > 0 && MestaTb.Text.Length > 0 && RestImages.Text.Length > 0)
            {

            }
        }
    }
}
