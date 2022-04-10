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
    /// Логика взаимодействия для RestPage.xaml
    /// </summary>
    public partial class RestPage : Page
    {
        private static User localUser;
        private static Restaurant localRest;

        private static List<string> imageList;

        public RestPage(User user, Restaurant restourant)
        {
            InitializeComponent();

            MyAccBtn.Content = user.Name.Substring(0, 2).ToUpper();

            localUser = user;
            localRest = restourant;
            if(localRest.Image != null)
            {
                imageList = localRest.Image.Split(',').ToList();
                if (imageList.Count == 1)
                {
                    BitmapImage myBitmapImage = new BitmapImage(new Uri($"../../../..{imageList[0]}", UriKind.Relative));
                    myBitmapImage.CacheOption = BitmapCacheOption.OnLoad;

                    ImageFirst.Source = myBitmapImage;
                }
                else if (imageList.Count == 2)
                {
                    BitmapImage myBitmapImageF = new BitmapImage(new Uri($"../../../..{imageList[0]}", UriKind.Relative));
                    BitmapImage myBitmapImageS = new BitmapImage(new Uri($"../../../..{imageList[1]}", UriKind.Relative));
                    myBitmapImageF.CacheOption = BitmapCacheOption.OnLoad;
                    myBitmapImageS.CacheOption = BitmapCacheOption.OnLoad;

                    ImageFirst.Source = myBitmapImageF;
                    ImageSecond.Source = myBitmapImageS;
                }
            }
            

             

            DataContext = restourant;
        }

        private void PhoneBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Контактный номер:\n{localRest.Phone}");
        }

        private void AddBookinBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBookingPage(localUser, localRest));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
