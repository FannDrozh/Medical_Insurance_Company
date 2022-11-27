﻿using Medical_Insurance_Company.ApplicationData;
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
    /// Логика взаимодействия для Persons.xaml
    /// </summary>
    public partial class Persons : Page
    {
        public Persons()
        {
            InitializeComponent();
            AppConnect.modelOdb = new MIC_BarashenkovEntities();
            ListPerson.ItemsSource = MIC_BarashenkovEntities.GetContext().Persons.ToList();
        }
        //private void BtnEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame.Navigate(new AddEditPage((sender as Button).DataContext as Person));
        //}
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = ListPerson.SelectedItems.Cast<Person>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MIC_BarashenkovEntities.GetContext().Persons.RemoveRange(hotelsForRemoving);
                    MIC_BarashenkovEntities.GetContext().SaveChanges();
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
                MIC_BarashenkovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListPerson.ItemsSource = MIC_BarashenkovEntities.GetContext().Persons.ToList();
            }
        }

    }
}
