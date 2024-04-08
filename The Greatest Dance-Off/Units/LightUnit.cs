using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Greatest_Dance_Off.Units
{ 
    class LightUnit : IUnit
    {
        public string Name { get; } = "ppp";
        public int Health { get; set; } = 75;
        public int Attack { get; set; } = 25;
        public int Defence { get; set; } = 74; // это рандом
        public int Dodge { get; set; } = 8;
        public int Cost { get; set; } = 60; // random to
        public LightUnit(LightUnit LightUnit)
        {
            Name = LightUnit.Name;
            Health = LightUnit.Health;
            Attack = LightUnit.Attack;
            Defence = LightUnit.Defence;
            Dodge = LightUnit.Dodge;
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
