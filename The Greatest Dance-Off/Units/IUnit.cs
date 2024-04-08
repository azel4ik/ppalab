using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Greatest_Dance_Off.Units
{
     interface IUnit
    {
        string Name { get; }
        int Health { get; set; }
        int Attack { get; set; }
        int Defence { get; set; }
        int Dodge { get; set; }
        int Сost { get; set; }
        int Distance { get; set; }

        void DoAttack(int Attack);
    }
}
