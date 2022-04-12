using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Restaurant localRestaurant;
        string imagesNames;
        private static int counter;
        List<Image> images=new List<Image>() { };
        readonly SolidColorBrush ok = new SolidColorBrush(Color.FromRgb(25, 169, 100));
        readonly SolidColorBrush notOk = new SolidColorBrush(Color.FromRgb(128, 128, 128));
        public AddEditRestPage(Ownership ownership, bool IsEdit)
        {
            InitializeComponent();
            localOwnership = ownership;
            if (IsEdit)
            {
                PageNameTb.Content = "Управление";
                localRestaurant = MainWindow.ent.Restaurant.Where(c => c.ID == localOwnership.RestaurantID).FirstOrDefault();
            }
            else
            {
                PageNameTb.Content = "Добавление";
            }
            if (localOwnership == null)
            {
                Abobus.Visibility = Visibility.Hidden;
                Abobus.Height = 0;
            }
            counter = 0;
            KitchenList.ItemsSource = MainWindow.ent.KitchenType.ToList();
            DataContext = localRestaurant;
            if (localRestaurant != null)
            {
                foreach (Image image in localRestaurant.Image1)
                {
                    if (image.Path != null && image.Path != "")
                    {
                        imagesNames += image.Path;
                        imagesNames += "; ";
                    }
                }
                RestImages.Text = imagesNames;
            }
        }

        private void AddRestBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckPlaceCount() && CheckTime()&& NameTb.Text.Length > 0 && AboutTb.Text.Length > 0&& AddressTb.Text.Length > 0 && MestaTb.Text.Length > 0 && RestImages.Text.Length > 0 && PhoneTb.Text.Length > 0&&HotWordsTB.Text.Length>0)
                {
                    if (localOwnership == null)
                    {
                        Restaurant restaurant = new Restaurant();
                        restaurant.Name = NameTb.Text;
                        restaurant.Description = AboutTb.Text;
                        restaurant.Address = AddressTb.Text;
                        restaurant.PlaceCount = Convert.ToInt32(MestaTb.Text);
                        restaurant.Phone = PhoneTb.Text;
                        restaurant.AveragePrice = CustomRatingBar.Value;
                        restaurant.HasTerrace = TerraceCB.IsChecked;
                        restaurant.StartTime = TimeSpan.Parse(StartTimePicker.Text);
                        restaurant.EndTime = TimeSpan.Parse(EndTimePicker.Text);
                        restaurant.Hotwords=HotWordsTB.Text;
                        bool isFirstImage = true;
                        foreach (Image image in images)
                        {
                            image.RestaurantID = restaurant.ID;
                            if (image.RestaurantID != null || image.RestaurantID != 0)
                            {
                                restaurant.Image1.Add(image);
                            }
                            if (isFirstImage)
                            {
                                restaurant.Image = image.Path;
                                isFirstImage = false;
                            }
                        }
                        MainWindow.ent.Restaurant.Add(restaurant);
                        localRestaurant = restaurant;
                        Ownership ownership = new Ownership();
                        ownership.User = CreatorPage.localUser;
                        ownership.Restaurant = localRestaurant;
                        MainWindow.ent.Ownership.Add(ownership);
                    }
                    MainWindow.ent.SaveChanges();
                    MessageBox.Show("Данные сохранены");
                    NavigationService.Navigate(new CreatorPage(CreatorPage.localUser));
                }
                else
                {
                    MessageBox.Show("Вы ввели не все значения");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool CheckTime()
        {
            try
            {
                if (TimeSpan.TryParse(StartTimePicker.Text, out TimeSpan startDate)&& TimeSpan.TryParse(EndTimePicker.Text, out TimeSpan endDate))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Неправильно введено время начала или окончания работы ресторана");
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
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
        private bool SetChecks()
        {
            Check10.Foreground = ok;
            if (!string.IsNullOrEmpty(NameTb.Text))
            {
                Check1.Foreground = ok;
            }
            else
            {
                Check1.Foreground = notOk;
                return false;
            }

            if (!string.IsNullOrEmpty(AboutTb.Text))
            {
                Check2.Foreground = ok;
            }
            else
            {
                Check2.Foreground = notOk;
                return false;
            }

            if (!string.IsNullOrEmpty(AddressTb.Text))
            {
                Check3.Foreground = ok;
            }
            else
            {
                Check3.Foreground = notOk;
                return false;
            }

            int.TryParse(MestaTb.Text, out int count);

            if (!string.IsNullOrEmpty(MestaTb.Text) && count > 0)
            {
                Check4.Foreground = ok;
                Check4.Foreground = ok;
            }
            else
            {
                Check4.Foreground = notOk;
                Check4.Foreground = notOk;

                return false;
            }
            if (string.IsNullOrEmpty(RestImages.Text))
            {
                Check5.Foreground = notOk;
            }
            else
            {
                Check5.Foreground = ok;
            }

            if (!string.IsNullOrEmpty(PhoneTb.Text) 
                //&& Regex.Match(PhoneTb.Text, @"^((\+7|7|8)+([0-9]){10})$").Success
                )
            {
                Check6.Foreground = ok;
                Check6.Foreground = ok;
            }
            else
            {
                Check6.Foreground = notOk;
                Check6.Foreground = notOk;

                return false;
            }

            if ((bool)TerraceCB.IsChecked)
            {
                Check7.Foreground = ok;
                Check7.Foreground = ok;
            }
            else
            {
                Check7.Foreground = notOk;
                Check7.Foreground = notOk;

                return false;
            }
            if (!string.IsNullOrEmpty(StartTimePicker.Text) && !string.IsNullOrEmpty(EndTimePicker.Text))
            {
                Check8.Foreground = ok;
            }
            else
            {
                Check8.Foreground = notOk;

            }

            if (!string.IsNullOrEmpty(HotWordsTB.Text))
            {
                Check10.Foreground = ok;
                Check10.Foreground = ok;
            }
            else
            {
                Check10.Foreground = notOk;
                Check10.Foreground = notOk;

                return false;
            }
            if (CustomRatingBar.Value>=0)
            {
                Check11.Foreground = ok;
            }

            return true;
        }


        private void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SetChecks();
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
                
                image.Path = System.IO.Path.GetFullPath(op.FileName);
                images.Add(image);
                imagesNames += image.Path + "; ";
                RestImages.Text = imagesNames;
                if (localOwnership != null)
                {
                    localRestaurant.Image1.Add(image);
                }
                //MainWindow.ent.SaveChanges();
                //SetAttachedImages();
                //CheckVisibility();
                //product.MainImagePath = filePath.Substring(filePath.LastIndexOf("/Images"));
            }
        }

        private void CustomRatingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetChecks();
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
        private void OpenListBtn_Click(object sender, RoutedEventArgs e)
        {
            counter++;

            if (counter % 2 == 0)
            {
                KitchenList.Visibility = Visibility.Hidden;
                KitchenList.Height = 0;
            }
            else
            {
                KitchenList.Visibility = Visibility.Visible;
                KitchenList.Height = 100;
            }
        }


        private void CurrentKitchenCb_Unchecked(object sender, RoutedEventArgs e)
        {
            if (localOwnership.Restaurant.ID != 0)
            {
                CheckBox cb = sender as CheckBox;

                if (cb.DataContext is KitchenType type)
                {
                    RestaurantKitchen restournat_Kitchen = MainWindow.ent.RestaurantKitchen.ToList().Find(c => c.KitchenID == type.ID && c.RestaurantID == localOwnership.Restaurant.ID);

                    if (restournat_Kitchen != null)
                    {
                        MainWindow.ent.RestaurantKitchen.Remove(restournat_Kitchen);
                        MainWindow.ent.SaveChanges();
                    }
                }
            }
        }


        private void CurrentKitchenCb_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (localOwnership!= null)
                {
                    CheckBox cb = sender as CheckBox;

                    if (cb.DataContext is KitchenType type)
                    {
                        RestaurantKitchen restournat_Kitchen = MainWindow.ent.RestaurantKitchen.ToList().Find(c => c.KitchenID == type.ID && c.RestaurantID == localOwnership.Restaurant.ID);

                        if (restournat_Kitchen == null)
                        {
                            RestaurantKitchen new_rest_Kitchen = new RestaurantKitchen
                            {
                                KitchenID = type.ID,
                                RestaurantID = localOwnership.Restaurant.ID
                            };

                            MainWindow.ent.RestaurantKitchen.Add(new_rest_Kitchen);
                            MainWindow.ent.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SetChecks();
        }
    }
}

