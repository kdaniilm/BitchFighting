using BitchFighting.viewmodel;
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

namespace BitchFighting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainWindowViewModel();
            DataContext = viewModel;

         

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //viewModel.GetHeroes().ForEach(x => testList.Items.Add(x.Name));
        }

        private void AddPersBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            //new AddFighter().Show();
        }

        private void Player1Btn_Click(object sender, RoutedEventArgs e)
        {

            Player1Btn.IsEnabled = false;
            Player2Btn.IsEnabled = true;
        }

        private void Player2Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            //new FightWindow().Show();
        }
    }
}
