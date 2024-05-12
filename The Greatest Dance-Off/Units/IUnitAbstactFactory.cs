using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Greatest_Dance_Off.Units
{
    interface IUnitAbstactFactory
    {
        public Unit Create();
    }

    class LIFactory : IUnitAbstactFactory
    {
        public Unit Create()
        {
            return new LightUnit();
        }
    }
    class HIFactory : IUnitAbstactFactory
    {
        public Unit Create()
        {
            return new HeavyUnit();
        }
    } 
    class ArrowFactory : IUnitAbstactFactory
    {
        public Unit Create()
        {
            return new Archar();
        }
    }
}
