using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ppa_lab_test_1
{
    public enum PositionType
    {
        OnevsOne,
        ThreevsThree,
        AllvsAll
    }
    public enum UnitType
    {
        HeavyUnit,
        LightUnit,
        Archer,
        Healer,
        Wizard,
        Default
    }
    abstract class GameCommand
    {
        public string? command_name;
        public string? command_status;
        public abstract void Execute();
        public abstract void Undo();
        public abstract void Redo();
    }


    class MakeMove : GameCommand
    {
        Game game;
        Army initialplayerstate;
        Army initialenemystate;
        Army finalplayerstate;
        Army finalenemystate;
        public MakeMove(Game r)
        {
            game = r;
            initialplayerstate = r.player.Copy();
            initialenemystate = r.enemy.Copy();
            command_name = "Make a move";
        }
        public override void Execute()
        {
            game.Move();
            finalenemystate = game.enemy.Copy();
            finalplayerstate = game.player.Copy();
        }

        public override void Undo()
        {
            game.player = initialplayerstate.Copy();
            game.enemy = initialenemystate.Copy();
        }
        public override void Redo()
        {
            game.player = finalplayerstate.Copy();
            game.enemy = finalenemystate.Copy();
        }

    }

    class PlayUpToTheEnd: GameCommand
    {
        Game game;
        Army initialplayerstate;
        Army initialenemystate;
        Army finalplayerstate;
        Army finalenemystate;

        public PlayUpToTheEnd(Game r)
        {
            game = r;
            initialplayerstate = r.player.Copy();
            initialenemystate = r.enemy.Copy();
            command_name = "Play up to the end";
        }
        public override void Execute()
        {
            while (game.player.units.Count() > 0 && game.enemy.units.Count() > 0)
            {
                Random randact = new Random();
                int val = randact.Next(4);
                switch(val)
                {
                    case 0:
                        game.Move();
                        break;
                    case 1:
                        game.player.PlaceGulyaiGorod();
                        break;
                    case 2:
                        game.player.WizardCloning();
                        break;
                }
                
            }
            game.Over = true;
            finalenemystate = game.enemy.Copy();
            finalplayerstate = game.player.Copy();
        }

        public override void Undo()
        {
            game.player = initialplayerstate.Copy();
            game.enemy = initialenemystate.Copy();
        }
        public override void Redo()
        {
            game.player = finalplayerstate.Copy();
            game.enemy = finalenemystate.Copy();
        }
    }

    class GatherArmy : GameCommand
    {
        Game game;
        int balance;
        
        public GatherArmy(Game r, int blnc)
        {
            game = r;
            command_name = "Gather Army";
            balance = blnc;
        }
        public override void Execute()
        {
            game.CreateArmy(balance);
        }

        public override void Undo()
        {

        }
        public override void Redo()
        {

        }
    }

    class SaveGame : GameCommand
    {
        Game game;
        public SaveGame(Game r)
        {
            game = r;
            command_name = "Save Game";
        }
        public override void Execute()
        {
            game.Save();
        }

        public override void Undo()
        {

        }
        public override void Redo()
        {

        } 
    }

    class CloneUnit : GameCommand
    {
        Game game;
        Army initialplayerstate;
        Army initialenemystate;
        Army finalplayerstate;
        Army finalenemystate;
        public CloneUnit(Game r)
        {
            game = r;
            command_name = "Clone Unit";
        }
        public override void Execute()
        {
            game.player.WizardCloning();
            finalenemystate = game.enemy.Copy();
            finalplayerstate = game.player.Copy();
        }

        public override void Undo()
        {
            game.player = initialplayerstate.Copy();
            game.enemy = initialenemystate.Copy();
        }
        public override void Redo()
        {
            game.player = finalplayerstate.Copy();
            game.enemy = finalenemystate.Copy();
        }
    }

    class PlaceGulyaiGorod : GameCommand
    {
        Game game;
        public PlaceGulyaiGorod(Game r)
        {
            game = r;
            command_name = "Place Gulyai-Gorod";
        }
        public override void Execute()
        {
            game.player.PlaceGulyaiGorod();
            //game.enemy.PlaceGulyaiGorod();
        }

        public override void Undo()
        {
            game.player.gg = null;
        }
        public override void Redo()
        {
            game.player.PlaceGulyaiGorod();
        }
    }

    public class Game
    {
        public Army player = new Army("Player");
        public Army enemy = new Army("Enemy");
        public IArmyPosition ArmyPosition = new OnevsOnePosition();
        public bool Over = false;
        public void SetArmyPosition(IArmyPosition ap)
        {
            ArmyPosition = ap;
            //ap.PositionUnits(this);
        }

        public void Move()
        {
            ArmyPosition.MoveAlgorithm(this);
        }

        public bool EndGame()
        {
            if (player.units.Count > enemy.units.Count) return true;
            return false;
        }

        public void Attack(Unit p_unt, Unit o_unt)
        {
            IUnit pdlp = new DeathLogProxy(p_unt);
            IUnit pdmlp = new DamageLogProxy(p_unt);
            IUnit pdsp = new DeathSoundProxy(p_unt);
            IUnit odlp = new DeathLogProxy(o_unt);
            IUnit odmlp = new DamageLogProxy(o_unt);
            IUnit odsp = new DeathSoundProxy(o_unt);

            if (p_unt.Alive()) 
            {
                if (enemy.gg != null) p_unt.DoAttack(enemy.gg, p_unt.Attack);
                else
                {
                    p_unt.DoAttack(o_unt, p_unt.Attack);
                    if(o_unt.Name.Contains("Heavy Infantry")&&o_unt.Health < o_unt.MaxHealth*0.2)
                    {
                        enemy.UnbuffHeavyUnit(o_unt);
                    }
                    odmlp.GetDamaged();
                }
                if (!o_unt.Alive()) 
                { 
                    odlp.Die(); 
                    odsp.Die(); 
                    return; 
                }
            }
            if (o_unt.Alive()) 
            {
                if (player.gg != null) o_unt.DoAttack(player.gg, o_unt.Attack);
                else
                {
                    o_unt.DoAttack(p_unt, o_unt.Attack);
                    if (o_unt.Name.Contains("Heavy Infantry") && o_unt.Health < o_unt.MaxHealth * 0.2)
                    {
                        player.UnbuffHeavyUnit(p_unt);
                    }
                    pdmlp.GetDamaged();
                }
                if (!p_unt.Alive()) 
                { 
                    pdlp.Die(); 
                    pdsp.Die(); 
                    return;
                }

            }
        }

        public void LongAttack()
        {
            List<Unit> parchers = player.FindUnit("Archer");
            List<Unit> oarchers = enemy.FindUnit("Archer");
            for (int i = 0; i < parchers.Count(); i++)
            {
                if (enemy.units.Count() > 0)
                {
                    Random rndt = new Random();
                    int value = rndt.Next(enemy.units.Count());
                    parchers[i].DoAttack(enemy.units[value], ((Archer)parchers[i]).ShootAttack);
                    if (enemy.units[value].Name.Contains("Heavy Infantry") && enemy.units[value].Health < enemy.units[value].MaxHealth * 0.2)
                    {
                        enemy.UnbuffHeavyUnit(enemy.units[value]);
                    }
                }
            }
            for (int i = 0; i < oarchers.Count(); i++)
            {
                if (player.units.Count() > 0)
                {
                    Random rndt = new Random();
                    int value = rndt.Next(player.units.Count());
                    oarchers[i].DoAttack(player.units[value], ((Archer)oarchers[i]).ShootAttack);
                    if (player.units[value].Name.Contains("Heavy Infantry") && player.units[value].Health < player.units[value].MaxHealth * 0.2)
                    {
                        player.UnbuffHeavyUnit(player.units[value]);
                    }
                }
            }
        }
        public void CreateArmy(int balance)
        {
            Console.WriteLine("The army is being created...");
            player.ChooseUnits(player.HICount, player.LICount, player.ACount, player.HCount, player.WCount);
            enemy.ChooseRandomUnits(balance);
        }
        public void Save()
        {
            Console.WriteLine("The game is being saved...");
        }
    }


    class GameManager : IObservable
    {
        GameCommand? command;
        CommandLogger observer = new CommandLogger();
        Stack<GameCommand> Undoable = new Stack<GameCommand>();
        Stack<GameCommand> Redoable = new Stack<GameCommand>();
        public void SetCommand(GameCommand c)
        {
            command = c;
            command.command_status = "Set";
            NotifyObservers();
        }
        public void Execute()
        {
            if (command != null)
            {
                command.Execute();
                Undoable.Push(command);
                command.command_status = "Executed";
                NotifyObservers();
            }
            else { Console.WriteLine("No command to execute"); }
        }
        public void Undo()
        {
            if (Undoable.Count != 0)
            {
                command = Undoable.Peek();
                Undoable.Pop().Undo();
                Redoable.Push(command);
                command.Undo();
                command.command_status = "Undone";
                NotifyObservers();
            }
            else { Console.WriteLine("No command to undo."); }
        }
        public void Redo()
        {
            if (Redoable.Count != 0)
            {
                command = Redoable.Peek();
                Redoable.Pop().Redo();
                Undoable.Push(command);
                command.Redo();
                command.command_status = "Redone";
                NotifyObservers();
            }
            else { Console.WriteLine("No command to redo."); }
        }
        public void NotifyObservers()
        {
            if (command != null && command.command_status != null && command.command_name != null)
            {
                observer.Update(command.command_name, command.command_status);
            }
        }
    }

    public class Army
    {
        public List<Unit> units = new List<Unit>();
        public Adapter? gg;
        public string ArmyName;
        public int HICount;
        public int LICount;
        public int ACount;
        public int HCount;
        public int WCount;
        
        public Army(string name)
        {
            ArmyName = name;
        }

        public void PlaceGulyaiGorod()
        {
            gg = new Adapter();
        }


        public void RemoveDeadUnits()
        {
            for (int i = 0; i < units.Count(); i++)
            {
                if (!units[i].Alive()) 
                {
                    units.RemoveAt(i); 
                    i--;
                }
            }
            if (gg != null) 
            {
                if (!gg.Alive()) gg = null;
            }
        }

        public void MoveInQueue(PositionType pt)
        {
            switch (pt)
            {
                case PositionType.OnevsOne:
                    if (units.Count() > 0)
                    {
                        Unit a = units[0];
                        if (a.Alive())
                        {
                            units.RemoveAt(0);
                            units.Add(a);
                        }
                    }
                break;
                case PositionType.ThreevsThree:
                    if (units.Count() > 1)
                    {
                        Unit a = units[0];
                        Unit b = units[1];
                        if (a.Alive())
                        {
                            units.RemoveAt(0);
                            units.RemoveAt(0);
                            units.Add(a);
                            units.Add(b);
                        }
                    }
                break;
                case PositionType.AllvsAll: break;
            }
        }
        public void ChooseUnits(int HINum, int LINum, int ANum, int HNum, int WNum)
        {
            for (int i = 0; i < HINum; i++) units.Add(new HeavyUnit()); 
            for (int i = 0; i < LINum; i++) units.Add(new LightUnit());
            for (int i = 0; i < ANum; i++) units.Add(new Archer());
            for (int i = 0; i < HNum; i++) units.Add(new Healer());
            for (int i = 0; i < WNum; i++) units.Add(new Wizard());

            //перемешать для случайного порядка в очереди
            for (int i = units.Count - 1; i >= 1; i--)
            {
                Random rand = new Random();
                int j = rand.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = units[j];
                units[j] = units[i];
                units[i] = temp;
            }
        }

        public void ChooseRandomUnits(int balance)
        {
            while (units.Count() < 1)
            {
                while (balance > 0)
                {
                    Random rnd = new Random();
                    Unit unt = new Unit();
                    int value = rnd.Next(0, 4);
                    switch (value)
                    {
                        case 0:
                            unt = new HeavyUnit();
                            balance -= unt.Price;
                            if (balance < 0) break;
                            HICount++;
                            units.Add(unt);
                            break;
                        case 1:
                            unt = new LightUnit();
                            balance -= unt.Price;
                            if (balance < 0) break;
                            LICount++;
                            units.Add(unt);
                            break;
                        case 2:
                            unt = new Archer();
                            balance -= unt.Price;
                            if (balance < 0) break;
                            ACount++;
                            units.Add(unt);
                            break;
                        case 3:
                            unt = new Healer();
                            balance -= unt.Price;
                            if (balance < 0) break;
                            HCount++;
                            units.Add(unt);
                            break;
                        case 4:
                            unt = new Wizard();
                            balance -= unt.Price;
                            if (balance < 0) break;
                            WCount++;
                            units.Add(unt);
                            break;
                        default: break;
                    }
                }
            }
        }

        public List<Unit> FindUnit(string str)
        {
            List<Unit> unts = new List<Unit>();
            for (int i = 0; i < units.Count(); i++)
            {
                if (units[i].Name.Contains(str)) unts.Add(units[i]);
            }
            return unts;
        }

        public List<int> FindUnitInx(string str)
        {
            List<int> unts = new List<int>();
            for (int i = 0; i < units.Count(); i++)
            {
                if (units[i].Name.Contains(str)) unts.Add(i);
            }
            return unts;
        }
        public UnitType CheckUnit(Unit unt)
        {
            if (unt.Name != null)
            {
                if (unt.Name.Contains("Heavy Infantry")) return UnitType.HeavyUnit;
                else if (unt.Name.Contains("Light Infantry")) return UnitType.LightUnit;
                else if (unt.Name.Contains("Archer")) return UnitType.Archer;
                else if (unt.Name.Contains("Healer")) return UnitType.Healer;
                else return UnitType.Wizard;
            }
            return UnitType.Default;
        }
        public void HealArmy(PositionType pst)
        {
            List<int> hlrs = FindUnitInx("Healer");
            if (hlrs.Count > 0)
            {
                if (units.Count() > 0)
                {
                    for (int i = 0; i < hlrs.Count(); i++)
                    {
                        int un = FindClosestUnitToHeal(hlrs[i], pst);
                        if (un == -1) return;
                        UnitType chu = CheckUnit(units[un]);
                        switch (chu)
                        {
                            case UnitType.HeavyUnit:
                                HeavyUnit hu = (HeavyUnit)(units[un]);
                                ((Healer)units[hlrs[i]]).Heal(hu);
                                break;
                            case UnitType.LightUnit:
                                LightUnit lu = (LightUnit)(units[un]);
                                ((Healer)units[hlrs[i]]).Heal(lu);
                                break;
                            case UnitType.Archer:
                                Archer a = (Archer)(units[un]);
                                ((Healer)units[hlrs[i]]).Heal(a);
                                break;
                            case UnitType.Healer:
                                Healer h = (Healer)(units[un]);
                                ((Healer)units[hlrs[i]]).Heal(h);
                                break;
                            case UnitType.Wizard:
                                Wizard w = (Wizard)(units[un]);
                                ((Healer)units[hlrs[i]]).Heal(w);
                                break;
                        }
                    }
                }
            }
        }

        public int FindClosestUnitToHeal(int hpos, PositionType pst)
        {
            int res = -1;
            switch (pst)
            {
                case PositionType.OnevsOne:
                    if (units.Count() > 1)
                    {
                        int before = -1;
                        int after = -1;
                        if (hpos - 1 >= 0) before = hpos - 1;
                        if (hpos + 1 < units.Count) after = hpos + 1;
                        if (before != -1 && after != -1)
                        {
                            if (units[after].Health < units[before].Health)
                            {
                                res = after;
                            }
                            else res = before;
                        }
                    }
                    break;
                case PositionType.ThreevsThree:
                    if (units.Count() > 1)
                    {
                        int close1 = -1;
                        int close2 = -1;
                        int close3 = -1;
                        if (hpos - 2 >= 0) close1 = hpos - 2;
                        if (hpos + 2 < units.Count) close3 = hpos + 2;
                        for (int i = 0;i<units.Count;i++)
                        {
                            if (i / 2 == hpos / 2 && i != hpos) close2 = i;
                        }
                        if (close1 != -1 && close2 != -1 && close3 != -1)
                        {
                            if (units[close1].Health < units[close3].Health && units[close1].Health < units[close2].Health)
                            {
                                res = close1;
                            }
                            else if (units[close1].Health < units[close3].Health && units[close1].Health > units[close2].Health) res = close2;
                            else res = close3;
                        }
                    }
                    break;
                case PositionType.AllvsAll:
                    if (units.Count() > 1)
                    {
                        int before = -1;
                        int after = -1;
                        if (hpos - 1 >= 0) before = hpos - 1;
                        if (hpos + 1 < units.Count) after = hpos + 1;
                        if (before != -1 && after != -1)
                        {
                            if (units[after].Health < units[before].Health)
                            {
                                res = after;
                            }
                            else res = before;
                        }
                    }
                    break;
                default:
                    break;
            }
            return res;
        }

        public int FindRandomLightorArcher()
        {
            List<int> unts = new List<int>();
            for (int i = 0; i < units.Count(); i++)
            {
                if (units[i].Name.Contains("Light Infantry") || units[i].Name.Contains("Archer")) unts.Add(i);
            }
            int val;
            Random randinx = new Random();
            val = randinx.Next(unts.Count);
            if (unts.Count > 0) return unts[val];
            return -1;
        }

        public void WizardCloning()
        {
            List<int> wzrds = new List<int>();
            wzrds = FindUnitInx("Wizard");
            if (wzrds.Count() > 0)
            {

                for (int i = 0; i < wzrds.Count(); i++)
                {
                    if (wzrds[i] > 0)
                    {
                        int inx = FindRandomLightorArcher();
                        if (inx > -1)
                        {
                            UnitType ut = CheckUnit(units[inx]);
                            switch (ut)
                            {
                                case UnitType.Archer:
                                    Wizard wz = (Wizard)units[wzrds[i]];
                                    Archer ar = (Archer)units[inx];
                                    if (units.Count < 5) units.Add(wz.Clone(ar));
                                    break;

                                case UnitType.LightUnit:
                                    Wizard wzl = (Wizard)units[wzrds[i]];
                                    LightUnit liu = (LightUnit)units[inx];
                                    if (units.Count < 5) units.Add(wzl.Clone(liu));
                                    break;

                            }
                            break;
                        }
                     }
                }
            }
        }
    
        public void BuffHeavyUnits(PositionType pt)
        {
            List<int> inxs = FindBuffPair(pt);
            for (int i = 0;i < inxs.Count;i++) 
            {
                BuffHeavyUnit(i);
            }
        }
        public void BuffHeavyUnit(int inx)
        {
            Random rndbuff = new Random();
            int c = rndbuff.Next(1);
            if (c == 0)
            {
                HeavyUnit hu = new HeavyInfantryHelmet(units[inx]);
                units[inx] = hu;
            }
            else
            {
                HeavyUnit hu = new HeavyInfantryCoolSword(units[inx]);
                units[inx] = hu;
            }
        }
        public void UnbuffHeavyUnit(Unit unt)
        {
            if (unt.Name.Contains(" с крутым мечом")) 
            {
                unt.Defence -= HeavyInfantryHelmet.buff;
                unt.Name.Replace(" с крутым мечом", ""); 
            }
            if (unt.Name.Contains(" со шлемом"))
            {
                unt.Attack -= HeavyInfantryCoolSword.buff;
                unt.Name.Replace(" со шлемом", "");
            }
        }

        public List<int> FindBuffPair(PositionType pt)
        {
            List<int> res = new List<int>();
            switch(pt)
            {
                case PositionType.OnevsOne: 
                    for (int i = 0; i < units.Count - 1; i++)
                    {
                        if (units[i].Name.Contains("Heavy Infantry") && units[i + 1].Name.Contains("Light Infantry")) //если легкий стоит сзади
                        {
                            if (!units[i].Name.Contains(" с крутым мечом") && !units[i].Name.Contains(" со шлемом"))
                            {
                                res.Add(i);
                            }
                        }
                    }
                    break;
                case PositionType.ThreevsThree:
                    for (int i = 0; i < units.Count - 2; i++)
                    {
                        if (units[i].Name.Contains("Heavy Infantry") && units[i + 1].Name.Contains("Light Infantry")) //если легкий стоит сзади
                        {
                            if (!units[i].Name.Contains(" с крутым мечом") && !units[i].Name.Contains(" со шлемом"))
                            {
                                res.Add(i);
                            }
                        }
                        else //сбоку тоже бафает
                        {
                            for(int p = 0; p < units.Count;i++)
                            {
                                if(p/2 == i/2 && p!=i)
                                {
                                    if (units[i].Name.Contains("Heavy Infantry") && units[i + 1].Name.Contains("Light Infantry"))
                                    {
                                        if (!units[i].Name.Contains(" с крутым мечом") && !units[i].Name.Contains(" со шлемом"))
                                        {
                                            res.Add(i);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case PositionType.AllvsAll:
                    for (int i = 0; i < units.Count - 1; i++)
                    {
                        if (units[i].Name.Contains("Heavy Infantry") && units[i + 1].Name.Contains("Light Infantry"))
                        {
                            if (!units[i].Name.Contains(" с крутым мечом") && !units[i].Name.Contains(" со шлемом"))
                            {
                                res.Add(i);
                            }
                        }
                    }
                    break;
            }
            
            return res;
        }
        public Army Copy()
        {
            Army a = new Army(ArmyName);
            a.HICount = HICount;
            a.LICount = LICount;
            a.ACount = ACount;
            a.HCount = HCount;
            a.WCount = WCount;
            if(gg != null) 
            {
                a.gg = new Adapter();
                a.gg.Health = gg.Health;
            }

            for (int i = 0; i < units.Count(); i++)
            {
                a.units.Add(units.ElementAt(i).Copy());
            }
            return a;
        }
    }
}
