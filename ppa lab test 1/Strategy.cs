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
        public void MoveAlgorithm(Game g, int movetype)
        {

        }
        public void PositionUnits(Game g)
        {

        }
    }
    public class OnevsOnePosition : IArmyPosition
    {
        public void MoveAlgorithm(Game g, int movetype)
        {
            if (g.player.units.Count() > 0 && g.enemy.units.Count() > 0)
            {
                g.Attack(g.player.units[0], g.enemy.units[0]);
                //if (g.player.units.Count() > 1 && g.enemy.units.Count() > 1)
                //{
                //    for (int i = 1;i < g.player.units.Count(); i++)
                //    {

                //    }
                //}
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
        public void PositionUnits(Game g)
        {
            for (int i = 0; i < g.player.units.Count(); i++)
            {
                PictureBox pupb = new PictureBox();
                pupb.Image = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif"));//g.player.units[i].Imgs.StandingStill;
                pupb.Location = new Point(g.player.units.Count() * 120 + 20, 10);
                pupb.Size = new Size(100, 120);
            }
            for (int i = 0; i < g.enemy.units.Count(); i++)
            {
                //PictureBox eupb = new PictureBox();
                //eupb.Image = Image.FromFile(Path.Combine(Application.StartupPath, "attacktest.gif")); //g.enemy.units[i].Imgs.StandingStill;
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
                g.Attack(g.player.units[2], g.enemy.units[2]);
                //if (g.player.units.Count() > 1 && g.enemy.units.Count() > 1)
                //{
                //    for (int i = 1; i < g.player.units.Count(); i++)
                //    {

                //    }
                //}
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
        public void PositionUnits(Game g)
        {
            for (int i = 0; i < g.player.units.Count(); i++)
            {

            }

        }
    }
    public class AllvsAllPosition : IArmyPosition
    {
        public void MoveAlgorithm(Game g, int movetype)
        {
            if (g.player.units.Count() > 0 && g.enemy.units.Count() > 0)
            {
                for (int i = 0;  i < g.player.units.Count(); i++)
                {
                    g.Attack(g.player.units[i], g.enemy.units[i]);
                }
                //if (g.player.units.Count() > 1 && g.enemy.units.Count() > 1)
                //{
                //    for (int i = 1; i < g.player.units.Count(); i++)
                //    {

                //    }
                //}
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
        public void PositionUnits(Game g)
        {
            for (int i = 0; i < g.player.units.Count(); i++)
            {

            }
        }
    }

}
