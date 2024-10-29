using Search.Database;
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

namespace Search.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            CBUsers.ItemsSource = App.Database.Roles.ToList();
            DGUsers.ItemsSource = App.Database.User.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Search = TBSearch.Text;

            if (TBSearch.Text == "")
            {
                MessageBox.Show("Вы ничего не ввели", "Ошибка");
            }
            else
            {

                DGUsers.ItemsSource = App.Database.User.Where(x => x.Name == Search || x.Login == Search || x.Roles.RoleName == Search).ToList();

            }
            Refresh();
        }



        private void CBUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh() 
        {
            var filtred = App.Database.User.ToList();

            var selectedRoleType = CBUsers.SelectedItem as Roles;
            var searchText = TBSearch.Text;

            if (selectedRoleType != null)
                filtred = filtred.Where(x => x.Roles.RoleName == selectedRoleType.RoleName).ToList();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filtred = filtred.Where(x => x.Name.Contains(searchText)).ToList();
            }

            DGUsers.ItemsSource = filtred.ToList();
        }
        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void BClean_Click(object sender, RoutedEventArgs e)
        {
            TBSearch.Text = "";
            CBUsers.SelectedItem = null;
            Refresh();
        }
    }

        
    }

