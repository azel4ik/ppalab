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
                p_unt.DoAttack(o_unt); 
                odmlp.GetDamaged();
                if (!o_unt.Alive()) { odlp.Die(); odsp.Die(); return; }
            }
            if (o_unt.Alive()) 
            { 
                o_unt.DoAttack(p_unt); 
                pdmlp.GetDamaged();
                if (!p_unt.Alive()) { pdlp.Die(); pdsp.Die(); return; }

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
        public void MoveInQueue()
        {
            if (units.Count() > 0)
            {
                Unit a = units[0];
                if (a.Alive())
                {
                    units.RemoveAt(0);
                    units.Add(a);
                }
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
