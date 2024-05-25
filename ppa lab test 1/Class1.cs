using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ppa_lab_test_1
{
    abstract class GameCommand //hello привет
    {
        public string? command_name;
        public abstract void Execute();
        public abstract void Undo();
        public abstract void Redo();
    }


    class MakeMove : GameCommand
    {
        Game game;
        public MakeMove(Game r)
        {
            game = r;
            command_name = "Make a move";
        }
        public override void Execute()
        {
            game.Move();
        }

        public override void Undo()
        {

        }
        public override void Redo()
        {

        }

    }

    class GatherArmy : GameCommand
    {
        Game game;
        public GatherArmy(Game r)
        {
            game = r;
            command_name = "Gather Army";
        }
        public override void Execute()
        {
            game.CreateArmy();
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
        public Army player = new Army();
        public Army enemy = new Army();
        public void Move()
        {
            Console.WriteLine("Units are making their moves...");
            player.units[0].DoAttack(enemy.units[0]);
            enemy.units[0].DoAttack(player.units[0]);
            //player.units[0].Heal(FindNearestUnit(player.units));
            //enemy.units[0].Heal(FindNearestUnit(enemy.units));
            //player.units[0].Copy(FindNearestUnit(player.units));
            //enemy.units[0].Copy(FindNearestUnit(enemy.units));
            //если есть archer, он стреляет
            player.RemoveDeadUnits(); //u
            enemy.RemoveDeadUnits();
            player.MoveInQueue();
            enemy.MoveInQueue();
        }
        public void CreateArmy()
        {
            Console.WriteLine("The army is being created...");
            player.ChooseUnits(player.HICount, player.LICount, player.ACount, player.HCount, player.WCount);
            enemy.ChooseUnits(1,1,1,1,1);
        }
        public void Save()
        {
            Console.WriteLine("The game is being saved...");
        }
        
    }


    class GameManager
    {
        GameCommand? command;
        Stack<GameCommand> Undoable = new Stack<GameCommand>();
        Stack<GameCommand> Redoable = new Stack<GameCommand>();
        public void SetCommand(GameCommand c)
        {
            Console.WriteLine($"Setting a command '{c.command_name}'...");
            command = c;
        }
        public void Execute()
        {
            if (command != null)
            {
                command.Execute();
                Undoable.Push(command);
                Console.WriteLine($"'{command.command_name}' has been executed.");
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
                Console.WriteLine($"'{command.command_name}' has been undone.");
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
                Console.WriteLine($"'{command.command_name}' has been redone.");
            }
            else { Console.WriteLine("No command to redo."); }
        }
    }

    public class Army
    {
        public List<Unit> units = new List<Unit>();
        public int HICount;
        public int LICount;
        public int ACount;
        public int HCount;
        public int WCount;

        public void RemoveDeadUnits()
        {
            for (int i = 0; i < units.Count(); i++)
            {
                if (!units[i].Alive()) { units.RemoveAt(i); i--; }
            }
        }
        public void MoveInQueue()
        {
            Unit a = units[0];
            if (a.Alive())
            {
                units.RemoveAt(0);
                units.Add(a);
            }
        }
        public void ChooseUnits(int HINum, int LINum, int ANum, int HNum, int WNum)
        {
            //может, как-то их потом перемешать для случайного порядка в очереди
            for (int i = 0; i < HINum; i++) units.Add(new HeavyUnit());
            for (int i = 0; i < LINum; i++) units.Add(new LightUnit());
            for (int i = 0; i < ANum; i++) units.Add(new Archer());
            for (int i = 0; i < HNum; i++) units.Add(new Healer());
            //for (int i = 0; i < WNum; i++) units.Add(new Wizard());

        }
    }

    //class Unit
    //{
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public int attack;
    //    public int health;
    //    public Unit() { }

    //    public Image StandImage { get; set; }
    //    public Image AttackImage { get; set; }

    //}

}
