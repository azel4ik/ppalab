using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Greatest_Dance_Off.Units
{
    class Archar : IUnit, IShooting
    {
        public string Name { get; } = "i";
        public int Health { get; set; } = 8;
        public int Attack { get; set; } = 40;
        public int Defence { get; set; } = 6;
        public int Dodge { get; set; } = 9; 
        public int Cost { get; set; } = 5;

        public int Distance { get; set; } = 15;

        public Archar(Archar Archar)
        {
            Name = Archar.Name;
            Health = Archar.Health;
            Attack = Archar.Attack;
            Defence = Archar.Defence;
            Dodge = Archar.Dodge;
        }

        public void DoAttack(int Attack)
        {
            int loss = Attack - Defence;
            if (loss > 0)
            {
                Health = Health - loss;
            }
        }

        public void ToShoot()
        {
            if (Distance == 15)
            {
                DoAttack(40);
            }
        }
    }
}
