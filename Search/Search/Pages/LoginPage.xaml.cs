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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Blogin_Click(object sender, RoutedEventArgs e)
        {
            var login = TBLogin.Text;
            var password = PBPassword.Password;

            var user = App.Database.User.FirstOrDefault(x => x.Login == login);
            if (user == null)
            {
                MessageBox.Show("Логин не существует");
                return;
            }
            if (user.Password != password)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            MessageBox.Show("Вы успешно вошли");
            NavigationService.Navigate(new MainPage());
        }
    }
}
