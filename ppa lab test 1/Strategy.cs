using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppa_lab_test_1
{
    public interface IArmyPosition
    {
        public void MoveAlgorithm(Army player, Army enemy)
        {

        }
    }
    public class OnevsOnePosition : IArmyPosition
    {
        public void MoveAlgorithm(Army player, Army enemy)
        {
            if (player.units.Count() > 0 && enemy.units.Count() > 0)
            {
                player.units[0].DoAttack(enemy.units[0]);
                enemy.units[0].DoAttack(player.units[0]);


                //player.units[0].Heal(FindNearestUnit(player.units));
                //enemy.units[0].Heal(FindNearestUnit(enemy.units));
                //player.units[0].Copy(FindNearestUnit(player.units));
                //enemy.units[0].Copy(FindNearestUnit(enemy.units));
                //если есть archer, он стреляет
                player.RemoveDeadUnits();
                enemy.RemoveDeadUnits();
                player.MoveInQueue();
                enemy.MoveInQueue();
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
