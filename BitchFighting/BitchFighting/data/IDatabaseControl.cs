using BitchFighting.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitchFighting.data
{
    interface IDatabaseControl
    {

        void Set(List<Hero> heroes);

        List<Hero> GetAll();

    }
}
