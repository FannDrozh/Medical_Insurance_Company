using Medical_Insurance_Company.ApplicationData;
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
            AppConnect.modelOdb = new MIC_BarashenkovEntities1();
            MainWindow mainWindow = new MainWindow();
            
        }

        private void Authorization_Bt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modelOdb.Authorizations.FirstOrDefault(x => x.Login == LoginBox.Text && x.Password == PasswordBox.Password);
                if(userObj == null)
                {
                    MessageBox.Show("Пользователь не зарегистрирован!", "Ошибка авторизации!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.ID_Role)
                    {
                        case 1: MessageBox.Show("Здравствуйте, Администратор " + userObj.Login + "!","Уведомление",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 2: MessageBox.Show("Здравствуйте, Сотрудник " + userObj.Login + "!", "Уведомление",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        default: MessageBox.Show("Данные не найдены!", "Уведомление",  
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Nameperson.Text = userObj.Login;
                    mainWindow.Show();
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString() + "Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            
        }
    }
}
