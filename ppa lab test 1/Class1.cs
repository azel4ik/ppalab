using ppa_lab_test_1.ppa_lab_test_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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
            game.Move(1);
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
            while (game.player.units.Count() > 0 || game.enemy.units.Count() > 0)
            {
                game.Move(1);
            }
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

    public class Game
    {
        public Army player = new Army("Player");
        public Army enemy = new Army("Enemy");
        public IArmyPosition ArmyPosition = new OnevsOnePosition();
        
        public void SetArmyPosition(IArmyPosition ap)
        {
            ArmyPosition = ap;
            ap.PositionUnits(this);
        }

        public void Move(int movetype)
        {
            ArmyPosition.MoveAlgorithm(this, movetype);
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
                p_unt.DoAttack(o_unt, p_unt.Attack); 
                odmlp.GetDamaged();
                if (!o_unt.Alive()) { odlp.Die(); odsp.Die(); return; }
            }
            if (o_unt.Alive()) 
            { 
                o_unt.DoAttack(p_unt, o_unt.Attack); 
                pdmlp.GetDamaged();
                if (!p_unt.Alive()) { pdlp.Die(); pdsp.Die(); return; }

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
                }
            }
            for (int i = 0; i < oarchers.Count(); i++)
            {
                if (player.units.Count() > 0)
                {
                    Random rndt = new Random();
                    int value = rndt.Next(player.units.Count());
                    oarchers[i].DoAttack(player.units[value], ((Archer)oarchers[i]).ShootAttack);
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
                            units.RemoveAt(1);
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
            //может, как-то их потом перемешать для случайного порядка в очереди
            for (int i = 0; i < HINum; i++) units.Add(new HeavyUnit()); 
            for (int i = 0; i < LINum; i++) units.Add(new LightUnit());
            for (int i = 0; i < ANum; i++) units.Add(new Archer());
            for (int i = 0; i < HNum; i++) units.Add(new Healer());
            for (int i = 0; i < WNum; i++) units.Add(new Wizard());

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
            List<Unit> hlrs = FindUnit("Healer");
            if (hlrs.Count > 0)
            {
                if (units.Count() > 0)
                {
                    for (int i = 0; i < hlrs.Count(); i++)
                    {
                        int val = 0;
                        for (int j = 0; j < units.Count(); j++)
                        {
                            if (hlrs[i] == units[j]) val = j;
                        }
                        Unit un = FindClosestUnitToHeal(val, pst);
                        UnitType chu = CheckUnit(un);
                        switch (chu)
                        {
                            case UnitType.HeavyUnit:
                                HeavyUnit hu = (HeavyUnit)un;
                                ((Healer)hlrs[i]).Heal(hu);
                                break;
                            case UnitType.LightUnit:
                                LightUnit lu = (LightUnit)un;
                                ((Healer)hlrs[i]).Heal(lu);
                                break;
                            case UnitType.Archer:
                                Archer a = (Archer)un;
                                ((Healer)hlrs[i]).Heal(a);
                                break;
                            case UnitType.Healer:
                                Healer h = (Healer)un;
                                ((Healer)hlrs[i]).Heal(h);
                                break;
                            case UnitType.Wizard:
                                Wizard w = (Wizard)un;
                                ((Healer)hlrs[i]).Heal(w);
                                break;
                        }

                    }
                }
            }
        }

        public Unit FindClosestUnitToHeal(int hpos, PositionType pst)
        {
            Unit res = new Unit();
            switch (pst)
            {
                case PositionType.OnevsOne:
                    if (units.Count() > 1)
                    {
                        Unit before = new Unit();
                        Unit after = new Unit();
                        if (hpos - 1 >= 0) before = units[hpos - 1];
                        if (hpos + 1 < units.Count) after = units[hpos + 1];
                        if (before != null && after != null)
                        {
                            if (after.Health < before.Health)
                            {
                                res = after;
                            }
                            else res = before;
                        }
                    }
                    break;
                //case PositionType.ThreevsThree:
                //    if (units.Count() > 1)
                //    {
                //        List
                //        if (hpos - 1 >= 0) before = units[hpos - 1];
                //        if (hpos + 1 < units.Count) after = units[hpos + 1];
                //        if (before != null && after != null)
                //        {
                //            if (after.Health < before.Health)
                //            {
                //                res = after;
                //            }
                //            else res = before;
                //        }
                //    }
                //    break;
                case PositionType.AllvsAll:
                    if (units.Count() > 1)
                    {
                        Unit before = new Unit();
                        Unit after = new Unit();
                        if (hpos - 1 >= 0) before = units[hpos - 1];
                        if (hpos + 1 < units.Count) after = units[hpos + 1];
                        if (before != null && after != null)
                        {
                            if (after.Health < before.Health)
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
        public Army Copy()
        {
            Army a = new Army(ArmyName);
            a.HICount = HICount;
            a.LICount = LICount;
            a.ACount = ACount;
            a.HCount = HCount;
            a.WCount = WCount;
            for (int i = 0; i < units.Count(); i++)
            {
                a.units.Add(units.ElementAt(i).Copy());
            }
            return a;
        }
    }

}
