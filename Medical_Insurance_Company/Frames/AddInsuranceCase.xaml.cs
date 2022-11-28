using Medical_Insurance_Company.ApplicationData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для AddInsuranceCase.xaml
    /// </summary>
    public partial class AddInsuranceCase : Page
    {
        public AddInsuranceCase()
        {
            InitializeComponent();
            AppConnect.modelOdb = new MIC_BarashenkovEntities1();
        }
        private void Congrats_Click(object sender, RoutedEventArgs e)
        {
            int per = int.Parse(Percent.Text);
            using (var context = new MIC_BarashenkovEntities1())
            {
                context.Insurance_Cases.Add(new Insurance_Cases
                {
                    Insurance_Case = InsurCase.Text,
                    Insurance__payment = per
                });
                if (context.SaveChanges() != null)
                {
                    MessageBox.Show("Вы добавили новый страховой случай", "Запись сохранена", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.NavigationService.Navigate(new Uri("Frames/InsuranceCases.xaml", UriKind.Relative));
                }
            }
        }
    }
}
