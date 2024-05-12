using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Greatest_Dance_Off.Units
{ 
    class LightUnit : Unit, IHealer
    {
        public LightUnit()
        {
            Attack = 25;
            Defence = 50;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health) * 10;
        }

        public new void Heal(int Healing)
            {
                if (СurrentHealth < Health && СurrentHealth > 0)
                {
                    int healAmount = Math.Min(Healing, Health - СurrentHealth);
                    Health += healAmount;
                }
            }

        }
    }
