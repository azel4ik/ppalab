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

    public interface IHealable
    {
        public void Recover(int Healing) { }
    }

    public class Unit: IUnit
    {
        public string Name; //название
        public int Health; //здоровье
        public int MaxHealth; // текущее здоровье которое будет на экране
        public int Attack; // сила аттаки
        public int Defence; // защита (можно придмать разные способы и создать отдельный класс с ними, например :щит, волшебная пыль для защиты, магический барьер и т.д.)
        public int Dodge; // изворотливость (аналогично с защитой, например: прыжок, полет, шаг в сторону и т.д)
        public int Price; // стоимость юнита (будет скалдываться из аттаки, извор и защиты, а затем умножаться на 10)
        public UnitStates us = UnitStates.Alive;
        public BasicImages ImgsP; //базовые картинки, которые есть у всех
        public BasicImages ImgsE; //базовые картинки, которые есть у всех

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
        public void DoAttack(Unit opponent, int attack) // хз как написать, но суть в том, что аттакующий и аттакованный юниты были живы для действия
        {
            Random rndAtt = new Random();
            int AttackValue = rndAtt.Next((int)(attack*0.75), (int)(attack * 1.25));
            //должна включаться анимация атаки у this
            //должна включаться анимация потери у defender
            if (Alive() && opponent.Alive())
            {
                int loss = Math.Max(AttackValue - opponent.Defence, 0);
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
            unt.ImgsP = new BasicImages(ImgsP.StandingStill, ImgsP.BasicAttack, ImgsP.Damaged, ImgsP.Healed, ImgsP.Dead);
            unt.ImgsE = new BasicImages(ImgsE.StandingStill, ImgsE.BasicAttack, ImgsE.Damaged, ImgsE.Healed, ImgsE.Dead);
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

    public class HeavyUnit : Unit, IHealable
    {
        public Image BuffedImage;
        public HeavyUnit()
        {
            Name += " Heavy Infantry";
            Attack = 60;
            Defence = 25;
            MaxHealth = 100;
            Health = MaxHealth;
            Price = (Attack + Defence + Health)/10;

            ImgsP = new BasicImages();

            ImgsP.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "маг стоит.gif"));
            ImgsP.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "маг колдует.gif"));
            ImgsP.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "мага бьют.gif"));
            ImgsP.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            BuffedImage = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));//?

            ImgsE = new BasicImages();

            ImgsE.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "маг стоит.gif"));
            ImgsE.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "маг колдует.gif"));
            ImgsE.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "мага бьют.gif"));
            ImgsE.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            BuffedImage = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));//?
        }

        public HeavyUnit Copy()
        {
            HeavyUnit unt = new HeavyUnit();
            unt.Name = Name;
            unt.Health = Health;
            unt.Attack = Attack;
            unt.Defence = Defence;
            unt.Dodge = Dodge;
            unt.Price = Price;
            unt.ImgsP = new BasicImages(ImgsP.StandingStill, ImgsP.BasicAttack, ImgsP.Damaged, ImgsP.Healed, ImgsP.Dead);
            unt.ImgsE = new BasicImages(ImgsE.StandingStill, ImgsE.BasicAttack, ImgsE.Damaged, ImgsE.Healed, ImgsE.Dead);
            unt.BuffedImage = BuffedImage;
            unt.us = us;
            return unt;
        }

        public new void Recover(int Healing)
        {
            if (MaxHealth < Health && MaxHealth > 0)
            {
                int healAmount = Math.Min(Healing, Health - MaxHealth);
                Health += healAmount;
            }
        }

    }
    public class LightUnit : Unit, IHealable, ICloneable
    {
        public LightUnit()
        {
            Name += " Light Infantry";
            Attack = 25;
            Defence = 50;
            MaxHealth = 100;
            Health = MaxHealth;
            Price = (Attack + Defence + Health) / 10;

            ImgsP = new BasicImages();

            ImgsP.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));

            ImgsE = new BasicImages();

            ImgsE.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "unittest.gif"));
            ImgsE.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
        }

        public object Clone()
        {
            LightUnit li = new LightUnit();
            li.Name = Name;
            li.Health = Health;
            li.Attack = Attack;
            li.Defence = Defence;
            li.Dodge = Dodge;
            li.Price = Price;
            li.ImgsP = new BasicImages(ImgsP.StandingStill, ImgsP.BasicAttack, ImgsP.Damaged, ImgsP.Healed, ImgsP.Dead);
            li.ImgsE = new BasicImages(ImgsE.StandingStill, ImgsE.BasicAttack, ImgsE.Damaged, ImgsE.Healed, ImgsP.Dead);
            li.us = us;

            return li;
        }

        public new void Recover(int Healing)
        {
            if (MaxHealth < Health && MaxHealth > 0)
            {
                int healAmount = Math.Min(Healing, Health - MaxHealth);
                Health += healAmount;
            }
        }
        

    }
    public class Archer : Unit, IHealable, ICloneable
    {
        public int ShootAttack;
        public Image ShootingImageP;
        public Image ShootingImageE;
        public Archer()
        {
            Name += " Archer";
            Attack = 35;
            ShootAttack = 60;
            Defence = 25;
            MaxHealth = 100;
            Health = MaxHealth;
            Price = (ShootAttack + Defence + Health) / 10;

            ImgsP = new BasicImages();


            ImgsP.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ShootingImageP = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif")); //

            ImgsE = new BasicImages();


            ImgsE.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "unittest.gif"));
            ImgsE.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ShootingImageE = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));//

        }

        public void DistantAttack(Unit opponent)
        {

        }
        public new void Recover(int Healing)
        {
            if (MaxHealth < Health && MaxHealth > 0)
            {
                int healAmount = Math.Min(Healing, Health - MaxHealth);
                Health += healAmount;
            }
        }

        public object Clone()
        {
            Archer arc = new Archer();
            arc.Name = Name;
            arc.Health = Health;
            arc.Attack = Attack;
            arc.Defence = Defence;
            arc.Dodge = Dodge;
            arc.Price = Price;
            arc.ImgsP = new BasicImages(ImgsP.StandingStill, ImgsP.BasicAttack, ImgsP.Damaged,ImgsP.Healed,ImgsP.Dead);
            arc.ImgsE = new BasicImages(ImgsE.StandingStill, ImgsE.BasicAttack, ImgsE.Damaged, ImgsE.Healed, ImgsE.Dead);
            arc.ShootingImageP = ShootingImageP;
            arc.ShootingImageE = ShootingImageE;
            arc.us = us;
            return arc;
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
            MaxHealth = 100;
            Health = MaxHealth;
            Price = (Attack + Defence + Health) / 10;

            ImgsP = new BasicImages();

            ImgsP.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            HealingImage = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));

            ImgsE = new BasicImages();

            ImgsE.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "unittest.gif"));
            ImgsE.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            HealingImage = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
        }
        public Healer Copy()
        {
            Healer arc = new Healer();
            arc.Name = Name;
            arc.Health = Health;
            arc.Attack = Attack;
            arc.Defence = Defence;
            arc.Dodge = Dodge;
            arc.Price = Price;
            arc.ImgsP = new BasicImages(this.ImgsP.StandingStill, ImgsP.BasicAttack, ImgsP.Damaged, ImgsP.Healed, ImgsP.Dead);
            arc.ImgsE = new BasicImages(this.ImgsE.StandingStill, ImgsE.BasicAttack, ImgsE.Damaged, ImgsE.Healed, ImgsE.Dead);
            arc.HealingImage = HealingImage;
            arc.us = us;
            return arc;
        }
        public void Heal(HeavyUnit u)
        {
            int value = (int)(Health * 0.5);
            u.Recover(value);
        }
        public void Heal(LightUnit u)
        {
            int value = (int)(Health * 0.5);
            u.Recover(value);
        }
        public void Heal(Archer u)
        {
            int value = (int)(Health * 0.5);
            u.Recover(value);
        }
        public void Heal(Healer u)
        {
            int value = (int)(Health * 0.5);
            u.Recover(value);
        }
        public void Heal(Wizard u)
        {
            int value = (int)(Health * 0.5);
            u.Recover(value);
        }

        public int FindClosestUnit()
        {
            int inx = 0;
            return inx;
        }

        public new void Recover(int Healing)
        {
            if (MaxHealth < Health && MaxHealth > 0)
            {
                int healAmount = Math.Min(Healing, Health - MaxHealth);
                Health += healAmount;
            }
        }
    }

    public class Wizard : Unit, IHealable
    {
        public Image CloningImage;
        public Wizard()
        {
            Name += " Wizard";
            Attack = 25;
            Defence = 50;
            MaxHealth = 100;
            Health = MaxHealth;
            Price = (Attack + Defence + Health) / 10;

            ImgsP = new BasicImages();

            ImgsP.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsP.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            CloningImage = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));

            ImgsE = new BasicImages();

            ImgsE.StandingStill = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.BasicAttack = Image.FromFile(Path.Combine(Application.StartupPath, "unittest.gif"));
            ImgsE.Damaged = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.Dead = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            ImgsE.Healed = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));
            CloningImage = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));

        }

        public Wizard Copy()
        {
            Wizard arc = new Wizard();
            arc.Name = Name;
            arc.Health = Health;
            arc.Attack = Attack;
            arc.Defence = Defence;
            arc.Dodge = Dodge;
            arc.Price = Price;
            arc.ImgsP = new BasicImages(this.ImgsP.StandingStill, ImgsP.BasicAttack, ImgsP.Damaged, ImgsP.Healed, ImgsP.Dead);
            arc.ImgsE = new BasicImages(this.ImgsE.StandingStill, ImgsE.BasicAttack, ImgsE.Damaged, ImgsE.Healed, ImgsE.Dead);
            arc.CloningImage = CloningImage;
            arc.us = us;
            return arc;
        }

        public void Clone(Archer a)
        {
            a.Clone();
        }
        public void Clone(LightUnit a)
        {
            a.Clone();
        }
        public new void Recover(int Healing)
        {
            if (MaxHealth < Health && MaxHealth > 0)
            {
                int healAmount = Math.Min(Healing, Health - MaxHealth);
                Health += healAmount;
            }
        }
    }

    public class GulyaiGorod
    {
        private int Health;
        private int Defence;
        private int MaxHealth;

        public GulyaiGorod()
        {
            Defence = 10;
            MaxHealth = Health = 30;
        }

        public int GetDefence()
        {
            return Defence;
        }

        public int GetStrength()
        {
            return 0;
        }

        public int GetHealth()
        {
            return Health;
        }

        public int GetMaxHealth()
        {
            return MaxHealth;
        }


        public void TakeDamage(int attack)
        {
            // oppAtt - сила атаки
            var minus = (int)Math.Round((decimal)((attack - Defence) / 100));
            Health -= minus;
        }

        public bool IsDead
        {
            get { return Health <= 0; }
        }
    }

    class Adapter : Unit
    {
        private GulyaiGorod gulyaiGorod;
        public Adapter()
        {
            gulyaiGorod = new GulyaiGorod();
            Name = "Gulyai Gorod";
            Attack = gulyaiGorod.GetStrength();
            Defence = gulyaiGorod.GetDefence();
            MaxHealth = gulyaiGorod.GetMaxHealth();
            Health = MaxHealth;
        }
        public new bool IsStillAlive()
        {
            return gulyaiGorod.IsDead;
        }

        public new void GetHit(int oppAtt)
        {
            gulyaiGorod.TakeDamage(oppAtt);
            Health = gulyaiGorod.GetHealth();
        }
    }

        public class BasicImages
    {
        public Image StandingStill;
        public Image BasicAttack;
        public Image Damaged;
        public Image Healed;
        public Image Dead;

        public BasicImages(Image a, Image b, Image c, Image d, Image e)
        {
            StandingStill = a;
            BasicAttack = b;
            Damaged = c;
            Healed = d;
            Dead = e;
        }
        public BasicImages() { }

        public BasicImages Copy()
        {
            BasicImages bi = new BasicImages(BasicAttack, StandingStill, Damaged, Healed, Dead);
            return bi;
        }
    }

}
