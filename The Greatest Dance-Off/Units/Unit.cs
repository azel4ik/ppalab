using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace The_Greatest_Dance_Off.Units
{
     public class Unit
    {
        protected string Name; //название
        protected int Health; //здоровье
        protected int СurrentHealth; // текущее здоровье которое будет на экране
        protected int Attack; // сила аттаки
        protected int Defence; // защита (можно придмать разные способы и создать отдельный класс с ними, например :щит, волшебная пыль для защиты, магический барьер и т.д.)
        protected int Dodge; // изворотливость (аналогично с защитой, например: прыжок, полет, шаг в сторону и т.д)
        protected int Price; // стоимость юнита (будет скалдываться из аттаки, извор и защиты, а затем умножаться на 10)

        public string NameOfUnit { get { return Name; } set { Name = value; } }
        public int HealthOfUnit
        {
            get { return Health; }
            set { Health = value; }
        }
        public int PowerOfAttack
        {
            get { return Attack; }
            set { Attack = value; }
        }
        public int VarityOfDefence
        {
            get { return Defence; }
            set { Defence = value; }
        }
        public int CurrentHealthPoints
        {
            get { return Health; }
            set { Health = value; }
        }

        public int CostOfUnit
        {
            get { return Price; }
            set { Price = (Attack + Defence + Health)*10; }
        }

        public bool Alive()
        {
            bool alive = true;
            if (Health <= 0) alive = false;
            return alive;
        }

        public void DoAttack(Unit attacker, Unit defender) // хз как написать, но суть в том, что аттакующий и аттакованный юниты были живы для действия
        {
            if (attacker.Alive() && defender.Alive())
            {
                int loss = Math.Max(attacker.Attack - defender.Defence, 0);
                defender.Health = Math.Max(defender.Health - loss, 0);
            }
        }
        internal IHealer Heal(int power) //стырила у Наташи
        {
            throw new NotImplementedException();
        }

    }
}
