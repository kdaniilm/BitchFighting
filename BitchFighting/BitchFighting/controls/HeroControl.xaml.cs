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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BitchFighting.controls
{
    /// <summary>
    /// Interaction logic for HeroControl.xaml
    /// </summary>
    public partial class HeroControl : UserControl
    {
        private MainWindow parentWindow;
        private Hero _hero;
        private OnClickHeroListener _onClickListener;
        private bool isChoose = false;


        public HeroControl()
        {
            InitializeComponent();
        }

        public HeroControl(Hero hero, OnClickHeroListener onClickListener, MainWindow parentWindow)
        {
            InitializeComponent();
            this._hero = hero;
            this._onClickListener = onClickListener;
            this.parentWindow = parentWindow;

            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(_hero.ImageUrl, UriKind.Absolute);
                bitmap.EndInit();

                heroImage.Source = bitmap;
            }
            catch { }

            nameText.Text = _hero.Name;
            descriptionText.Text = _hero.Description;
            hpText.Text = _hero.Hp.ToString();
            attackText.Text = _hero.Attack.ToString();
            defenseText.Text = _hero.Defense.ToString();

        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if(!isChoose && parentWindow.CheckHero(_hero))
                mainGrid.Effect = new DropShadowEffect() { BlurRadius = 15, ShadowDepth = 1, Color = parentWindow.viewModel.currentColor };

        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            if(!isChoose)
                mainGrid.Effect = null;

        }
        
        public void ResetExcretion()
        {
            isChoose = false;
            mainGrid.Effect = null;
        }

        private void mainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(!isChoose && parentWindow.CheckHero(_hero))
            {
                parentWindow.UpdateHeroes(this);
                isChoose = true;
                _onClickListener.ChangeHero(_hero);
            }
  
        }

        public Hero GetHero() => _hero;
    }
}
