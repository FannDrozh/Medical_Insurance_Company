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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Medical_Insurance_Company.Frames
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Page
    {
        public Registr()
        {
            InitializeComponent();
            AppConnect.modelOdb = new MIC_BarashenkovEntities1();
            Role.ItemsSource = MIC_BarashenkovEntities1.GetContext().Role_Users.ToList();
        }

        private void Cong_Click(object sender, RoutedEventArgs e)
        {
            int id;
            bool result = int.TryParse(Role.SelectedValue.ToString(), out id);
            using (var context = new MIC_BarashenkovEntities1())
            {
                Role.DataContext = context;
                context.Authorizations.Add(new ApplicationData.Authorization
                {
                    Login = Login.Text,
                    Password = Password.Text,
                    ID_Role = id
                });
                if (context.SaveChanges() != null)
                {
                    MessageBox.Show("Вы зарегистрировали нового пользователя", "Запись сохранена", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
