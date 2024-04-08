using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Greatest_Dance_Off.Units
{
    class HeavyUnit : IUnit
    {
        public string Name { get; } = "uuuu";
        public int Health { get; set; } = 100;
        public int Attack { get; set; } = 50;
        public int Defence { get; set; } = 74; // это рандом
        public int Dodge { get; set; } = 16;
        public int Cost { get; set; } = 60; // random too

        public HeavyUnit(HeavyUnit HeavyUnit)
        {
            Name = HeavyUnit.Name;
            Health = HeavyUnit.Health;
            Attack = HeavyUnit.Attack;
            Defence = HeavyUnit.Defence;
            Dodge = HeavyUnit.Dodge;
        }

        public void DoAttack(int Attack)
        {
            int loss = Attack - Defence;
            if (loss > 0)
            {
                Health = Health - loss;
            }
        }

    }
}

