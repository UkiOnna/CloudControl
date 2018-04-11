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

namespace Cloud.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Window window;
        public RegistrationPage(Window win)
        {
            InitializeComponent();
            window = win;
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {

            Userr user = new Userr();
            UserrService serv = new UserrService();
            if (login.Text != null && password.Text != null && password.Text.Length >= 8 && password.Text == password2.Text)
            {
                try
                {
                    user.Login = login.Text;
                    user.Password = password.Text;
                    serv.Create(user);
                    window.Content = new AuthentificationPage(window);
                }

                catch
                {
                    MessageBox.Show("Такой логин уже существует");
                }
            }
            else
            {
                MessageBox.Show("Вы неправильно заполнили поля проверьте правильность написания");
            }
        }
    }
}
