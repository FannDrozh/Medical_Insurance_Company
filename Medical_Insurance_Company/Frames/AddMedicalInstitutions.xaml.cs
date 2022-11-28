using Medical_Insurance_Company.ApplicationData;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Medical_Insurance_Company.Frames
{
    /// <summary>
    /// Логика взаимодействия для AddMedicalInstitutions.xaml
    /// </summary>
    public partial class AddMedicalInstitutions : Page
    {
        
        public AddMedicalInstitutions()
        {
            InitializeComponent(); 
            AppConnect.modelOdb = new MIC_BarashenkovEntities1();
            Service.ItemsSource = MIC_BarashenkovEntities1.GetContext().Medical_Services.ToList();

        }
        private void Congrats_Click(object sender, RoutedEventArgs e)
        {
            string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss",
                                        "MM/dd/yyyy hh:mm tt", "yyyy-MM-dd HH:mm:ss, fff" };

            CultureInfo provider = new CultureInfo("en-US");
            DateTime Date_of_Signing1 = DateTime.Parse(Date_of_Signing.Text);
            double PriceMed1 = Convert.ToDouble(PriceMed.Text);
            int id;
            bool result = int.TryParse(Service.SelectedValue.ToString(), out id);
            using (var context = new MIC_BarashenkovEntities1())
            {
                Service.DataContext= context;
                context.Medical_Institutions.Add(new Medical_Institutions
                {
                    Name_Med_Ins = NameMedCentr.Text,
                    ID_Medical_Services = id,
                    Price = PriceMed1,
                    Phone = Phone.Text,
                    Contract_Period = ContractPeriod.Text,
                    Date_of_Signing = Date_of_Signing1
                });
                if (context.SaveChanges() != null)
                {
                    MessageBox.Show("Вы добавили новый мед. центр", "Запись сохранена", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
