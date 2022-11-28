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
    /// Логика взаимодействия для AddDocumentationInsuranceCases.xaml
    /// </summary>
    public partial class AddDocumentationInsuranceCases : Page
    {
        public AddDocumentationInsuranceCases()
        {
            InitializeComponent();
            AppConnect.modelOdb = new MIC_BarashenkovEntities1();
        }
        private void Congrats_Click(object sender, RoutedEventArgs e)
        {
            DateTime DateInsCase1 = DateTime.Parse(DateInsCase.Text);
            int idPerson = int.Parse(IDInsPerson.Text);
            int idInsCase = int.Parse(IDInsCase.Text);
            int idMedInst = int.Parse(IDMedCentr.Text);
            using (var context = new MIC_BarashenkovEntities1())
            {
                context.Documentation_Insurance_Cases.Add(new Documentation_Insurance_Cases
                {
                    Date_Insuranse_Case = DateInsCase1,
                    ID_Person = idPerson,
                    ID_Insuranse_Case = idInsCase,
                    Comment = Comm.Text,
                    ID_Medical_Institution = idMedInst
                });
                if (context.SaveChanges() != null)
                {
                    MessageBox.Show("Вы зафиксировали новый страховой случай", "Запись сохранена", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.NavigationService.Navigate(new Uri("Frames/DocumentationInsuranceCases.xaml", UriKind.Relative));
                }
            }
        }
    }
}
