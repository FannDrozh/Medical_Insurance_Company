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
using System.Windows.Shapes;

namespace Medical_Insurance_Company
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Bt_Click(object sender, RoutedEventArgs e)
        {
            if(LoginBox.Text.Length > 0) 
            {
                if(PasswordBox.Password.Length > 0)
                {
                    
                }
                else
                {
                    MessageBox.Show("Введите верный логин!");
                }
            }
            else
            {
                MessageBox.Show("Введите верный логин!");
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
