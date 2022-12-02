using Medical_Insurance_Company.ApplicationData;
using Medical_Insurance_Company.Frames;
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

namespace Medical_Insurance_Company
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string log;
        
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.modelOdb = new MIC_BarashenkovEntities1();
            MainMenu.Visibility = Visibility.Hidden;
        }
        //Окно подачи заявки
        private void Sumbit_Application_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new SumbitApp();
        }
        //Застрахованные люди
        private void Insured_People_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Frames.Persons();
        }
        //Добавление мед. центров
        private void Add_Med_Center_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new AddMedicalInstitutions();
        }
        //Мед. центры
        private void Med_Center_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new MedicalInstitutions();
        }
        //Страховые случаи
        private void Insurence_Cases_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new InsuranceCases();
        }
        //Документация
        private void Doc_Ins_Cas_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new DocumentationInsuranceCases();
        }
        //Регистрация
        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Registr();
        }
        


    }
}
