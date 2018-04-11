using Microsoft.Win32;
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

namespace Cloud.Pages
{
    /// <summary>
    /// Логика взаимодействия для FilesPage.xaml
    /// </summary>
    public partial class FilesPage : Page
    {
        private Window window;
        private Userr user;
        public FilesPage(Window win,Userr us)
        {
            InitializeComponent();
            window = win;
            user = us;
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            //dialog.DefaultExt = ".png";
            dialog.ShowDialog();
            string filePath = dialog.FileName;
            string shortFileName = filePath.Substring(filePath.LastIndexOf('\\') + 1); 
            byte[] imageData;
            using (System.IO.FileStream fs = new System.IO.FileStream(filePath, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }
            FileService serv = new FileService();
            FileBase file = new FileBase();
            file.Name = shortFileName;
            file.binaryData = imageData;
            file.UserId = user.Id;
            serv.Create(file);
        }

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            FileService serv = new FileService();
            List<FileBase> files = new List<FileBase>();
            files = serv.SelectAll();
            // сохраним первый файл из списка
            if (files.Count > 0)
            {
                for (int i = 0; i > files.Count; i++)
                {
                    if (files[i].Id == user.Id)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(files[i].Name, FileMode.OpenOrCreate))
                        {
                            fs.Write(files[i].binaryData, 0, files[0].binaryData.Length);

                            MessageBox.Show("Изображение  сохранено " + files[i].Name);
                        }
                    }
                }
            }
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            FileService serv = new FileService();
            serv.Delete(0);//какойто выбранный файл (не успел реализовать листбокс с файлами)
        }
    }
}
