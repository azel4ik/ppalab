using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppa_lab_test_1
{
    public interface IArmyPosition
    {
        public void MoveAlgorithm(Game g)
        {

        }
    }
    public class OnevsOnePosition : IArmyPosition
    {
        public void MoveAlgorithm(Game g)
        {
            if (g.player.units.Count() > 0 && g.enemy.units.Count() > 0)
            {
                g.Attack(g.player.units[0], g.enemy.units[0]);

                //player.units[0].Heal(FindNearestUnit(player.units));
                //enemy.units[0].Heal(FindNearestUnit(enemy.units));
                //player.units[0].Copy(FindNearestUnit(player.units));
                //enemy.units[0].Copy(FindNearestUnit(enemy.units));
                //если есть archer, он стреляет
                g.player.RemoveDeadUnits();
                g.enemy.RemoveDeadUnits();
                g.player.MoveInQueue();
                g.enemy.MoveInQueue();
            }
        }
    }
    public class ThreevsThreePosition : IArmyPosition
    {
        public void MoveAlgorithm(Army player, Army enemy)
        {
            int gap = 3;
        }
    }
    public class AllvsAllPosition : IArmyPosition
    {
        public void MoveAlgorithm()
        {

        }
    }

}
