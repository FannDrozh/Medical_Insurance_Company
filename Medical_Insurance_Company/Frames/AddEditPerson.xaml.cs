using System;
using Medical_Insurance_Company.ApplicationData;
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
using System.Globalization;

namespace Medical_Insurance_Company.Frames
{
    /// <summary>
    /// Логика взаимодействия для AddEditPerson.xaml
    /// </summary>
    public partial class AddEditPerson : Page
    {
        private Person _currentPerson = new ApplicationData.Person();

        public AddEditPerson(ApplicationData.Person selectedPerson)
        {
            InitializeComponent();
            if (selectedPerson != null)
                _currentPerson = selectedPerson;
            DataContext = _currentPerson;
        }
        private void Congrats_Click(object sender, RoutedEventArgs e)
        {
            string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss",
                                        "MM/dd/yyyy hh:mm tt", "yyyy-MM-dd HH:mm:ss, fff" };

            CultureInfo provider = new CultureInfo("en-US");
            DateTime Birthdate1 = DateTime.Parse(Birthdate.Text);
            DateTime Date_of_Signing1 = DateTime.Parse(Date_of_Signing.Text);
            using (var context = new MIC_BarashenkovEntities())
            {
                context.Persons.Add(new ApplicationData.Person
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
                }
            }
        }
    }
}
