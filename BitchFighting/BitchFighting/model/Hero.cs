using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitchFighting.model
{
    class Hero
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Hp { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
    }
}
