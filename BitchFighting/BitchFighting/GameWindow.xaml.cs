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
        }
    }
}
