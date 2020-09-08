using BitchFighting.controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BitchFighting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, OnClickHeroListener
    {
        public MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainWindowViewModel();
            DataContext = viewModel;


      
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            ResetHeroesList();
        }

        private void AddPersBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddFighter().ShowDialog();
            ResetHeroesList();
        }

        private void Player1Btn_Click(object sender, RoutedEventArgs e)
        {
            if(viewModel.isPlayerReady())
            {
                bool result = viewModel.ApplyHero();
                if (result)
                {

                    new GameWindow(viewModel.GetP1(), viewModel.GetP2()).Show();
                    this.Close();
                }
                else
                {
                    Player1Btn.IsEnabled = false;
                    Player2Btn.IsEnabled = true;
                }
            }


        }

        private void Player2Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetHeroesList()
        {
            heroWrapPanel.Children.Clear();
            viewModel.GetHeroes().ForEach(x => heroWrapPanel.Children.Add(new HeroControl(x, this, this)));
        }

        public void ChangeHero(Hero hero)
        {
            viewModel.ChooseHero(hero);
        }

        public void UpdateHeroes(HeroControl heroControl)
        {
            foreach(var element in heroWrapPanel.Children)
            {
                if((element as HeroControl) != heroControl && viewModel.CheckHero((element as HeroControl).GetHero()))
                    (element as HeroControl).ResetExcretion();

            }
        }

        public bool CheckHero(Hero hero)
        {
            return this.viewModel.CheckHero(hero);
        }
    }
        public interface OnClickHeroListener
        {
            void ChangeHero(Hero hero);

            void UpdateHeroes(HeroControl heroControl);
            bool CheckHero(Hero hero);
        }
}
