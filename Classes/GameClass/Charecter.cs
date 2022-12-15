using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WRPG.Classes.GameClass.DataClasses;

namespace WRPG.Classes
{
    public class Charecter : Entity
    {
        public string Race { get; init; }
        public string Class { get; init; }

        public event Action<string>? StatChange;
        public Charecter(string name, string race, string @class) : base(name)
        {
            Race = race;
            Class = @class;
        }
        public Charecter() : base("None") {Race = Class = "None"; }
        public void AddStat(string name, float value,string source)
        {
            Type type = this.GetType();
            foreach (var i in type.GetProperties())
            {
                if (i.Name == name)
                {
                    var tmp = (States)i.GetValue(this)!;                    
                    tmp.AddStat(new Stat(name, value,source));
                    StatChange!.Invoke(name);
                }
            }
        }

        public string Info() => $"Names: {Name}\nRace: {Race}\nClass: {Class}\nLevel: {Level.CurrentLevel}\nXp: {Level.CurrentXp}\n" +
                                $"Stats:\n\t{Hp.SumValue}\n\n\t{Damage.SumValue}\n\n\t{Defence.SumValue}";
    }
}
