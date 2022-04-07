﻿using System;
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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private static User localUser;

        private static readonly DateTime startMorning = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5,0,0);
        private static readonly DateTime endMorning = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11,0,0);

        public ClientPage(User user)
        {
            InitializeComponent();
            
            localUser = user;

            MyAccBtn.Content = user.Name.Substring(0, 2).ToUpper();

            RestGrid.ItemsSource = MainWindow.ent.Restaurant.ToList();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            CountPeopleTb.Text = String.Empty;
            SearchTb.Text = String.Empty;
            MorningCb.IsChecked = false;
            NowCb.IsChecked = false;
            OpenTerCb.IsChecked = false;

            RestGrid.ItemsSource = MainWindow.ent.Restaurant.ToList();
        }

        private void MyAccBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyBookingPage(localUser));
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchSettings();
        }

        private void CountPeopleTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchSettings();
        }

        private void Cb_Checked(object sender, RoutedEventArgs e)
        {
            SearchSettings();
        }

        private void SearchSettings()
        {
            List<Restaurant> searchList = new List<Restaurant>();
            List<Restaurant> countList = new List<Restaurant>();
            List<Restaurant> nowList = new List<Restaurant>();
            List<Restaurant> terList = new List<Restaurant>();
            List<Restaurant> morningList = new List<Restaurant>();

            List<Restaurant> resList = new List<Restaurant>();

            HashSet<Restaurant> restHashSet = new HashSet<Restaurant>();

            if (!string.IsNullOrEmpty(SearchTb.Text))
            {
                searchList = MainWindow.ent.Restaurant.Where(c => c.Name.StartsWith(SearchTb.Text) || c.Hotwords.Contains(SearchTb.Text)).ToList();
            }

            if (!string.IsNullOrEmpty(CountPeopleTb.Text) && int.TryParse(CountPeopleTb.Text, out int n))
            {
                countList = MainWindow.ent.Restaurant.Where(c => c.PlaceCount >= n).ToList();
            }

            if ((bool)NowCb.IsChecked)
            {
                nowList = MainWindow.ent.Restaurant.Where(c => c.StartTime.Value.Hours < DateTime.Now.Hour && c.EndTime.Value.Hours > DateTime.Now.Hour).ToList();
            }

            if ((bool)OpenTerCb.IsChecked)
            {
                terList = MainWindow.ent.Restaurant.Where(c => c.HasTerrace == true).ToList();
            }

            if ((bool)MorningCb.IsChecked)
            {
                morningList = MainWindow.ent.Restaurant.Where(c => c.EndTime.Value.Hours >= startMorning.Hour && c.EndTime.Value.Hours <= endMorning.Hour).ToList();
            }

            resList = restHashSet.Concat(searchList)
                    .Concat(countList)
                    .Concat(nowList)
                    .Concat(terList)
                    .Concat(morningList).Distinct().ToList();

            RestGrid.ItemsSource = resList.ToList();
        }

        private void RestGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Restaurant restourant = RestGrid.SelectedItem as Restaurant;

            if (restourant != null)
            {
                NavigationService.Navigate(new RestPage(localUser, restourant));
            }
        }
    }
}
