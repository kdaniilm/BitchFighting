using BitchFighting.data;
using BitchFighting.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitchFighting.viewmodel
{
    class MainWindowViewModel
    {

        private List<Hero> _heroes;

        public MainWindowViewModel()
        {

        }

        public List<Hero> GetHeroes()
        {
            _heroes = DatabaseControl.getInstance().GetAll();
            return _heroes;
        }

        public void AddHero(Hero hero)
        {
            _heroes.Add(hero);

        }

    }
}
