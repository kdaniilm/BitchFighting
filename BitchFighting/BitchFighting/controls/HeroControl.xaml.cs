using BitchFighting.model;
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
        private Hero _hero;
        


        public HeroControl()
        {
            InitializeComponent();
        }

        public HeroControl(Hero hero)
        {
            InitializeComponent();
            this._hero = hero;

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
            mainGrid.Effect = new DropShadowEffect() { BlurRadius = 15, ShadowDepth = 1, Color = Colors.Blue };
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            mainGrid.Effect = null;
        }
    }
}
