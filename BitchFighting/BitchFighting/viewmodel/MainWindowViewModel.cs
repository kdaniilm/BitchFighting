using BitchFighting.data;
using BitchFighting.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BitchFighting.viewmodel
{
    public class MainWindowViewModel
    {

        private List<Hero> _heroes;
        private bool isFirst = true;
        public Color currentColor;
        private Hero p1, p2;

        public MainWindowViewModel()
        {
            currentColor = Colors.Blue;
        }

        public List<Hero> GetHeroes()
        {
            _heroes = DatabaseControl.getInstance().GetAll();
            return _heroes;
        }


        public void ChooseHero(Hero hero)
        {
            if(isFirst)
            {
                p1 = hero;
            }
            else
            {
                p2 = hero;
            }

        }

        public bool ApplyHero()
        {
            if (isFirst)
            {
                isFirst = false;
                currentColor = Colors.Red;
                return false;
            }
            else
            {
                return true;
            }
            return false;
        }

        public bool isPlayerReady()
        {
            if (isFirst)
                return p1 != null;
            else
                return p2 != null;
        }


        public bool CheckHero(Hero hero)
        {
            return this.p1 != hero || isFirst;
        }

        public Hero GetP1() => p1;
        public Hero GetP2() => p2;

    }
}
