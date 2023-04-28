using ExamProgram.Domain.Configurations;
using ExamProgram.Packages;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ExamProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
           

            InitializeComponent();
        }
        private void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
            MainWPageFoodList.Content = new AddPage();
        }
        private void Button_Click_Users(object sender, RoutedEventArgs e)
        {
            MainWPageFoodList.Content = new SelectPage();
        }

       
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click_Chat(object sender, RoutedEventArgs e)
        {
            MainWPageFoodList.Content = new ChatsPage();
        }
    }
}
