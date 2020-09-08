using BitchFighting.data;
using BitchFighting.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitchFighting.viewmodel
{
    class AddFighterViewModel
    {
        private List<Hero> _heroes;

        public AddFighterViewModel()
        {
            GetHeroes();
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
