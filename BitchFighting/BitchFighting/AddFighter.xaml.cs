
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
    /// <summary>
    /// Interaction logic for AddFighter.xaml
    /// </summary>
    public partial class AddFighter : Window
    {

        private AddFighterViewModel viewModel;
        Random rand = new Random();

        public AddFighter()
        {
            InitializeComponent();
            viewModel = new AddFighterViewModel();
            DataContext = viewModel;


        private void PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit(e.Key.ToString().ToCharArray().ToList().Last())) 
            { 
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameTb.Text.Length > 0 && DescriptionTb.Text.Length > 0 && HPTb.Text.Length > 0 && DefenceTb.Text.Length > 0 && AttackTb.Text.Length > 0 && ImageUrlTb.Text.Length > 0)
            {

                viewModel.AddHero(new model.Hero() { Attack = Convert.ToInt32(AttackTb), Defense = Convert.ToInt32(DefenceTb.Text), Description = DescriptionTb.Text, Hp = Convert.ToInt32(HPTb.Text), Name = NameTb.Text, ImageUrl = null, Id = rand.Next(0,25991295)});

                this.Hide();
                new MainWindow().ShowDialog();
            }
            else
            {
                MessageBox.Show("Complite all datas!");
            }
        }
    }
}
