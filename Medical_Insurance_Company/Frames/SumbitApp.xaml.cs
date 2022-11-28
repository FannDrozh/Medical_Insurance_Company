using Medical_Insurance_Company.ApplicationData;
using Medical_Insurance_Company.Frames;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Medical_Insurance_Company
{
    /// <summary>
    /// Логика взаимодействия для SumbitApp.xaml
    /// </summary>
    public partial class SumbitApp : Page
    {
        
        public SumbitApp()
        {
            InitializeComponent();
            AppConnect.modelOdb = new MIC_BarashenkovEntities1();
            
        }

        private void Congrats_Click(object sender, RoutedEventArgs e)
        {
            string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss",
                                        "MM/dd/yyyy hh:mm tt", "yyyy-MM-dd HH:mm:ss, fff" };

            CultureInfo provider = new CultureInfo("en-US");
            DateTime Birthdate1 = DateTime.Parse(Birthdate.Text);
            DateTime Date_of_Signing1 = DateTime.Parse(Date_of_Signing.Text);
            using (var context = new MIC_BarashenkovEntities1())
            {
                context.Persons.Add(new Person
                {
                    Surname = Surname.Text, 
                    Name = Name.Text,
                    Middle_Name = MiddleName.Text,
                    Birthdate = Birthdate1,
                    Passport_Series_Number = PassportSeriesNumber.Text,
                    Phone = Phone.Text,
                    Contract_Period = Contract_Period.Text,
                    Date_of_Signing = Date_of_Signing1
                });
                if (context.SaveChanges() != null)
                {
                    MessageBox.Show("Вы подали заявку!", "Запись сохранена", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.NavigationService.Navigate(new Uri("Frames/Persons.xaml", UriKind.Relative));
                }
            }
        }
    }
}
