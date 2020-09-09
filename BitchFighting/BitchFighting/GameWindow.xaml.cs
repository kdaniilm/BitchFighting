using BitchFighting.model;
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
using System.Windows.Shapes;

namespace BitchFighting
{
    public partial class GameWindow : Window
    {
        GameWindowViewModel viewModel;
        public GameWindow()
        {
            InitializeComponent();
        }
        public GameWindow(Hero firstPlayer, Hero secondPlayer)
        {
            InitializeComponent();
            viewModel = new GameWindowViewModel(firstPlayer, secondPlayer);
            DataContext = viewModel;
            hp1.Value = hp1.Maximum = firstPlayer.Hp;
            hp2.Value = hp2.Maximum = secondPlayer.Hp;
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(firstPlayer.ImageUrl, UriKind.Absolute);
                bitmap.EndInit();

                LeftHero.Source = bitmap;
            }
            catch { }

            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(secondPlayer.ImageUrl, UriKind.Absolute);
                bitmap.EndInit();

                RightHero.Source = bitmap;
            }
            catch { }
        }

        private void LeftAttack_Click(object sender, RoutedEventArgs e)
        {
            LogBox.Items.Add(viewModel.Attack());
            string tmp = viewModel.CheckHP(this);
            if(tmp != null)
                LogBox.Items.Add(tmp);
            LogBox.ScrollIntoView(LogBox.Items[LogBox.Items.Count - 1]);
            hp2.Value = viewModel.secondPlayer.Hp;
            LeftAttack.IsEnabled = false;
            RightAttack.IsEnabled = true;
        }

        private void RightAttack_Click(object sender, RoutedEventArgs e)
        {
            LogBox.Items.Add(viewModel.Attack());
            string tmp = viewModel.CheckHP(this);
            if (tmp != null)
                LogBox.Items.Add(tmp);
            LogBox.ScrollIntoView(LogBox.Items[LogBox.Items.Count - 1]);
            hp1.Value = viewModel.firstPlayer.Hp;
            LeftAttack.IsEnabled = true;
            RightAttack.IsEnabled = false;
        }
    }
}
