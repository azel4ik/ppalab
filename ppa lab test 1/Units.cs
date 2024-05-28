using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ppa_lab_test_1
{
    public enum UnitStates
    {
        Alive,
        Dead,
        Damaged
    }
    interface IUnitAbstactFactory
    {
        public Unit Create();
    }
    public interface IClonable
    {
        public IClonable Clone();
    }

    public interface IHealable
    {
        public void Recover(int Healing) { }
    }

    public class Unit: IUnit
    {
        public string Name; //название
        public int Health; //здоровье
        public int СurrentHealth; // текущее здоровье которое будет на экране
        public int Attack; // сила аттаки
        public int Defence; // защита (можно придмать разные способы и создать отдельный класс с ними, например :щит, волшебная пыль для защиты, магический барьер и т.д.)
        public int Dodge; // изворотливость (аналогично с защитой, например: прыжок, полет, шаг в сторону и т.д)
        public int Price; // стоимость юнита (будет скалдываться из аттаки, извор и защиты, а затем умножаться на 10)
        public UnitStates us = UnitStates.Alive;
        public BasicImages Imgs; //базовые картинки, которые есть у всех

        #region
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
        #endregion
        public bool Alive()
        {
            if (Health <= 0) return false;
            return true;
        }

        public Unit()
        {

        }

        public Unit(string name)
        {
            Name = name;
        }
        public void DoAttack(Unit opponent) // хз как написать, но суть в том, что аттакующий и аттакованный юниты были живы для действия
        {
           

            //как-то сохраняться состояние до атаки
            //должна включаться анимация атаки у this
            //должна включаться анимация потери у defender
            if (Alive() && opponent.Alive())
            {
                int loss = Math.Max(Attack - opponent.Defence, 0);
                opponent.Health = Math.Max(opponent.Health - loss, 0);
                //opponent.dmlp.GetDamaged();

            }
            //Imgs.BasicAttack
            //opponent.Imgs.Damaged
        }
        internal IHealable Recover(int power) //стырила у Наташи
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            us = UnitStates.Dead;
        }

        public void GetDamaged()
        {
            us = UnitStates.Damaged;
        }

        public Unit Copy()
        {
            Unit unt = new Unit();
            unt.Name = Name;
            unt.Health = Health;
            unt.Attack = Attack;
            unt.Defence = Defence;
            unt.Dodge = Dodge;
            unt.Price = Price;
            unt.Imgs = new BasicImages();
            unt.us = us;
            return unt;
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
    class ArcherFactory : IUnitAbstactFactory
    {
        public Unit Create()
        {
            return new Archer();
        }
    }

    class HeavyUnit : Unit, IHealable
    {
        Image BuffedImage;
        public HeavyUnit()
        {
            Name += " Heavy Infantry";
            Attack = 60;
            Defence = 25;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health)/10;

            //Imgs.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //BuffedImage = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
        }
        public new void Recover(int Healing)
        {
            if (СurrentHealth < Health && СurrentHealth > 0)
            {
                int healAmount = Math.Min(Healing, Health - СurrentHealth);
                Health += healAmount;
            }
        }

    }
    class LightUnit : Unit, IHealable
    {
        public LightUnit()
        {
            Name += " Light Infantry";
            Attack = 25;
            Defence = 50;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health) / 10;

            //Imgs.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
        }

        public new void Recover(int Healing)
        {
            if (СurrentHealth < Health && СurrentHealth > 0)
            {
                int healAmount = Math.Min(Healing, Health - СurrentHealth);
                Health += healAmount;
            }
        }

    }
    class Archer : Unit, IHealable
    {
        Image ShootingImage;
        public Archer()
        {
            Name += " Archer";
            Attack = 35;
            Defence = 25;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health) / 10;

            //Imgs.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //ShootingImage = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));

        }

        public void DistantAttack()
        {

        }
        public new void Recover(int Healing)
        {
            if (СurrentHealth < Health && СurrentHealth > 0)
            {
                int healAmount = Math.Min(Healing, Health - СurrentHealth);
                Health += healAmount;
            }
        }
    }
    public class Healer : Unit, IHealable
    {
        Image HealingImage;
        public Healer()
        {
            Name += " Healer";
            Attack = 25;
            Defence = 50;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health) / 10;

            //Imgs.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //HealingImage = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
        }

        public void Heal()
        {

        }

        public int FindClosestUnit()
        {
            int inx = 0;
            return inx;
        }

        public new void Recover(int Healing)
        {
            if (СurrentHealth < Health && СurrentHealth > 0)
            {
                int healAmount = Math.Min(Healing, Health - СurrentHealth);
                Health += healAmount;
            }
        }
    }

    public class Wizard : Unit, IHealable
    {
        Image CloningImage;
        public Wizard()
        {
            Name += " Wizard";
            Attack = 25;
            Defence = 50;
            СurrentHealth = 100;
            Health = СurrentHealth;
            Price = (Attack + Defence + Health) / 10;

            //Imgs.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //Imgs.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            //CloningImage = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));

        }

        public void Clone()
        {

        }
        public new void Recover(int Healing)
        {
            if (СurrentHealth < Health && СurrentHealth > 0)
            {
                int healAmount = Math.Min(Healing, Health - СurrentHealth);
                Health += healAmount;
            }
        }
    }

    public class BasicImages
    {
        public Image StandingStill;
        public Image BasicAttack;
        public Image Damaged;
        public Image Healed;
        public Image Dead;

        public BasicImages Copy()
        {
            BasicImages bi = new BasicImages();
            bi.BasicAttack = BasicAttack;
            bi.StandingStill = StandingStill;
            bi.Damaged = Damaged;
            bi.Healed = Healed;
            bi.Dead = Dead;
            return bi;
        }
    }

}
