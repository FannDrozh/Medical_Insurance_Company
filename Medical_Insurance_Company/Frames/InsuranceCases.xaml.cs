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
    /// Логика взаимодействия для InsuranceCases.xaml
    /// </summary>
    public partial class InsuranceCases : Page
    {
        public InsuranceCases()
        {
            InitializeComponent();
            ListInsurenceCases.ItemsSource = MIC_BarashenkovEntities1.GetContext().Insurance_Cases.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Frames/AddInsuranceCase.xaml", UriKind.Relative));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var InsCaseForRemoving = ListInsurenceCases.SelectedItems.Cast<Insurance_Cases>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {InsCaseForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MIC_BarashenkovEntities1.GetContext().Insurance_Cases.RemoveRange(InsCaseForRemoving);
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
                ListInsurenceCases.ItemsSource = MIC_BarashenkovEntities1.GetContext().Insurance_Cases.ToList();
            }
        }
    }
}
