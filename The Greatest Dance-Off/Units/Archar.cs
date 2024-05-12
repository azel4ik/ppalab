using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Greatest_Dance_Off.Units
{
    class Archar : Unit
    {
        public Archar()
        { 
            Attack = 35;
            Defence = 25;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health) * 10;
        }
    }
}
