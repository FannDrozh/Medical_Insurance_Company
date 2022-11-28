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
    /// Логика взаимодействия для MedicalInstitutions.xaml
    /// </summary>
    public partial class MedicalInstitutions : Page
    {
        public MedicalInstitutions()
        {
            InitializeComponent();
            AppConnect.modelOdb = new MIC_BarashenkovEntities1();
            ListMedInst.ItemsSource = MIC_BarashenkovEntities1.GetContext().Medical_Institutions.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Frames/AddMedicalInstitutions.xaml", UriKind.Relative));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var MedInstForRemoving = ListMedInst.SelectedItems.Cast<Medical_Institutions>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {MedInstForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MIC_BarashenkovEntities1.GetContext().Medical_Institutions.RemoveRange(MedInstForRemoving);
                    MIC_BarashenkovEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MIC_BarashenkovEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListMedInst.ItemsSource = MIC_BarashenkovEntities1.GetContext().Persons.ToList();
            }
        }
    }
}
