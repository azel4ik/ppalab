using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ppa_lab_test_1
{
    interface IUnitAbstactFactory
    {
        public Unit Create();
    }
    public interface IClonable
    {
        public IClonable Clone();
    }

    public interface IHealer
    {
        public void Heal(int Healing) { }
    }

    public class Unit
    {
        public string Name; //название
        public int Health; //здоровье
        public int СurrentHealth; // текущее здоровье которое будет на экране
        public int Attack; // сила аттаки
        public int Defence; // защита (можно придмать разные способы и создать отдельный класс с ними, например :щит, волшебная пыль для защиты, магический барьер и т.д.)
        public int Dodge; // изворотливость (аналогично с защитой, например: прыжок, полет, шаг в сторону и т.д)
        public int Price; // стоимость юнита (будет скалдываться из аттаки, извор и защиты, а затем умножаться на 10)

        //public string NameOfUnit { get { return Name; } set { Name = value; } }
        //public int HealthOfUnit
        //{
        //    get { return Health; }
        //    set { Health = value; }
        //}
        //public int PowerOfAttack
        //{
        //    get { return Attack; }
        //    set { Attack = value; }
        //}
        //public int VarityOfDefence
        //{
        //    get { return Defence; }
        //    set { Defence = value; }
        //}
        //public int CurrentHealthPoints
        //{
        //    get { return Health; }
        //    set { Health = value; }
        //}

        //public int CostOfUnit
        //{
        //    get { return Price; }
        //    set { Price = (Attack + Defence + Health) * 10; }
        //}

        public bool Alive()
        {
            if (Health <= 0) return false;
            return true;
        }



        public void DoAttack(Unit defender) // хз как написать, но суть в том, что аттакующий и аттакованный юниты были живы для действия
        {
            //как-то сохраняться состояние до атаки
            //должна включаться анимация атаки у this
            //должна включаться анимация потери у defender
            if (Alive() && defender.Alive())
            {
                int loss = Math.Max(Attack - defender.Defence, 0);
                defender.Health = Math.Max(defender.Health - loss, 0);
            }
        }
        internal IHealer Heal(int power) //стырила у Наташи
        {
            throw new NotImplementedException();
        }

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
            return new Archer();
        }
    }

    class HeavyUnit : Unit, IHealer
    {
        public HeavyUnit()
        {
            Attack = 60;
            Defence = 25;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health)/10;
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

    class LightUnit : Unit, IHealer
    {
        public LightUnit()
        {
            Attack = 25;
            Defence = 50;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health) / 10;
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
    class Archer : Unit
    {
        public Archer()
        {
            Attack = 35;
            Defence = 25;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health) / 10;
        }
    }
    public class Healer : Unit
    {
        public Healer()
        {
            Attack = 25;
            Defence = 50;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health) / 10;
        }
    }
}
