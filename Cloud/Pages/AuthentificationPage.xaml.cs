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
    /// Логика взаимодействия для AuthentificationPage.xaml
    /// </summary>
    public partial class AuthentificationPage : Page
    {
        private Window window;
        public AuthentificationPage(Window win)
        {
            InitializeComponent();
            window = win;
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            UserrService service = new UserrService();
            List < Userr >users= service.SelectAll();
          
            bool isPassword = false;
            for(int i = 0; i < users.Count; i++)
            {
                if (login.Text !=null && login.Text == users[i].Login)
                {
                    if (users[i].Password == password.Text)
                    {
                        isPassword = true;
                    }
                }

                if (isPassword)
                {
                    window.Content = new FilesPage(window, users[i]);
                    break;
                }

            }
            if(!isPassword)
            MessageBox.Show("Вы ввели неверные данные");
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            window.Content = new RegistrationPage(window);
        }
    }
}
