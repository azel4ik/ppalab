using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ppa_lab_test_1
{
    public interface IArmyPosition
    {
        public void MoveAlgorithm(Game g, int movetype) { }
    }
    public class OnevsOnePosition : IArmyPosition
    {
        public void MoveAlgorithm(Game g, int movetype)
        {
            if (g.player.units.Count() > 0 && g.enemy.units.Count() > 0)
            {
                g.Attack(g.player.units[0], g.enemy.units[0]);
                g.LongAttack();
                g.player.HealArmy(PositionType.OnevsOne);
                g.enemy.HealArmy(PositionType.OnevsOne);
                
                g.player.MoveInQueue(PositionType.OnevsOne);
                g.enemy.MoveInQueue(PositionType.OnevsOne);
                g.player.RemoveDeadUnits();
                g.enemy.RemoveDeadUnits();
            }
        }
    }
    public class ThreevsThreePosition : IArmyPosition
    {
        public void MoveAlgorithm(Game g, int movetype)
        {
            if (g.player.units.Count() > 0 && g.enemy.units.Count() > 0)
            {
                g.Attack(g.player.units[0], g.enemy.units[0]);
                g.Attack(g.player.units[1], g.enemy.units[1]);
                
                g.player.MoveInQueue(PositionType.ThreevsThree);
                g.enemy.MoveInQueue(PositionType.ThreevsThree);
                g.player.RemoveDeadUnits();
                g.enemy.RemoveDeadUnits();
            }
        }
    }
    public class AllvsAllPosition : IArmyPosition
    {
        public void MoveAlgorithm(Game g, int movetype)
        {
            int playernum = g.player.units.Count();
            int enemynum = g.enemy.units.Count();
            if (playernum > 0 && enemynum > 0)
            {
                for (int i = 0;  i < Math.Min(playernum,enemynum); i++)
                {
                    g.Attack(g.player.units[i], g.enemy.units[i]);
                }
                
                g.player.MoveInQueue(PositionType.AllvsAll);
                g.enemy.MoveInQueue(PositionType.AllvsAll);
                g.player.RemoveDeadUnits();
                g.enemy.RemoveDeadUnits();
            }
        }
    }

}
