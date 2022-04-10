using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace Pract_pr_22.RolePages
{
    /// <summary>
    /// Логика взаимодействия для AddEditRestPage.xaml
    /// </summary>
    public partial class AddEditRestPage : Page
    {
        Ownership localOwnership;
        Restaurant restaurant;
        public AddEditRestPage(Ownership ownership, bool IsEdit)
        {
            InitializeComponent();
            localOwnership = ownership;

            if (localOwnership != null)
            {
                restaurant = MainWindow.ent.Restaurant.Where(c => c.ID == localOwnership.RestaurantID).FirstOrDefault();
                if (restaurant == null)
                {
                    PageNameTb.Content = "Добавление";
                    IsEdit = false;
                }
                else
                {
                    PageNameTb.Content = "Управление";
                    IsEdit = true;
                }
            }
            KitchenCB.ItemsSource = MainWindow.ent.KitchenType.ToList();
            KitchenTypeList.ItemsSource = MainWindow.ent.KitchenType.ToList();
            DataContext = restaurant;
            CheckValidation();
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
            if (CheckPlaceCount() && NameTb.Text.Length > 0 && AboutTb.Text.Length > 0 && AddressTb.Text.Length > 0 && MestaTb.Text.Length > 0
                //&& RestImages.Text.Length > 0 
                && PhoneTb.Text.Length > 0)
            {
                if (localOwnership == null)
                {
                    Restaurant restaurant = new Restaurant()
                    {
                        Name = NameTb.Text,
                        Description = AboutTb.Text,
                        Address = AddressTb.Text,
                        PlaceCount = Convert.ToInt32(MestaTb.Text),
                        Phone = PhoneTb.Text
                    };
                    MainWindow.ent.Restaurant.Add(restaurant);
                }
                MainWindow.ent.SaveChanges();
                MessageBox.Show("Данные сохранены");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Вы ввели неправильные значения");
            }
        }
        private bool CheckPlaceCount()
        {
            try
            {
                if (int.TryParse(MestaTb.Text, out var number))
                {
                    int cost = Convert.ToInt32(MestaTb.Text);

                    if (cost < 0)
                    {
                        MessageBox.Show("Кол-во мест не может быть отрицательным");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Кол-во мест должно состоять только из цифр");
                    return false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show($"Кол-во мест не может содержать буквы - {MestaTb.Text}");
                MestaTb.Text = String.Empty;
                return false;
            }
        }


        private bool IsButtonEnabled()
        {
            if (NameTb.Text.Length > 0 && AboutTb.Text.Length > 0 && AddressTb.Text.Length > 0 && MestaTb.Text.Length > 0 && RestImages.Text.Length > 0 && PhoneTb.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CheckValidation()
        {
            if (restaurant != null)
            {
                if (restaurant.Name != "")
                {
                    NameCheck.Foreground = Brushes.Green;
                }

            }
            else
            {
                NameCheck.Foreground = Brushes.Red;
            }
        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckValidation();
        }
        private void Refresh()
        {
            KitchenCB.ItemsSource = MainWindow.ent.KitchenType.ToList();
            KitchenTypeList.ItemsSource = MainWindow.ent.KitchenType.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            string folderpath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Images\\";
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            bool? myResult;
            myResult = op.ShowDialog();
            if (myResult != null && myResult == true)
            {
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }
                string filePath = folderpath + System.IO.Path.GetFileName(op.FileName);
                Image image = new Image();
                //mainPath = mainPath.Replace(@"\"[0], '/');
                image.Path = filePath;
                image.RestaurantID = restaurant.ID;
                restaurant.Image1.Add(image);
                MainWindow.ent.SaveChanges();
                //SetAttachedImages();
                //CheckVisibility();
                //product.MainImagePath = filePath.Substring(filePath.LastIndexOf("/Images"));
            }
        }

        private void CustomRatingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var bc = new BrushConverter();
            if (CustomRatingBar.Value == 0)
            {
                Ruble2.Foreground = (Brush)bc.ConvertFrom("#000000");
                Ruble3.Foreground = (Brush)bc.ConvertFrom("#000000");
            }
            if (CustomRatingBar.Value == 1)
            {
                Ruble2.Foreground= (Brush)bc.ConvertFrom("#4BB9F8");
                Ruble3.Foreground= (Brush)bc.ConvertFrom("#000000");
            }
            if (CustomRatingBar.Value == 2)
            {
                Ruble2.Foreground = (Brush)bc.ConvertFrom("#4BB9F8");
                Ruble3.Foreground = (Brush)bc.ConvertFrom("#4BB9F8");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

