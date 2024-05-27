using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace ppa_lab_test_1
{
    public interface IUnit
    {
        public void Die();
        public void GetDamaged();
    }

    public class DeathSoundProxy: IUnit
    {
        private Unit _unit;
        private WaveStream deatheffectstream;
        private WaveOut outdeatheffect;
        public DeathSoundProxy(Unit unit) 
        {
            _unit = unit;
            deatheffectstream = new AudioFileReader("sword-clash.wav");
            outdeatheffect = new();
            outdeatheffect.Init(deatheffectstream);
        }
        public void Die()
        {
            if (_unit.us != UnitStates.Dead) _unit.Die();
            deatheffectstream.CurrentTime = new TimeSpan(0L);
            outdeatheffect.Play();
        }
        public void GetDamaged() { }
    }

    public class DeathLogProxy : IUnit
    {
        private Unit _unit;


        public DeathLogProxy(Unit unit) 
        {
            _unit = unit;

        }
        public void Die()
        {
            StreamWriter swdl = new StreamWriter("DeathLog.txt", true);
            if (_unit.us != UnitStates.Dead) _unit.Die();
            string msg = $"[{System.DateTime.Now}]: The unit '{_unit.Name}' is Dead.";
            swdl.WriteLine(msg);
            swdl.Close();

        }
        public void GetDamaged() { }
    }
    public class DamageLogProxy: IUnit
    {
        private Unit _unit;

        public DamageLogProxy(Unit unit) 
        {
            _unit = unit;
        }
        public void GetDamaged()
        {
            StreamWriter swdml = new StreamWriter("DamageLog.txt", true);
            if (_unit.us != UnitStates.Damaged) _unit.Die();
            string msg = $"[{System.DateTime.Now}]: The unit '{_unit.Name}' has been Damaged. Their current health is {_unit.Health}";
            swdml.WriteLine(msg);
            swdml.Close();
        }
        public void Die() { }
    }
}
