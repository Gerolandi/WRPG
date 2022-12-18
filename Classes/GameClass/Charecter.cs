using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            Level.LevelChanged += Stats.LevelUpdate;
        }
        public Charecter() : base("None") {Race = Class = "None"; }

  //      public string Info() => $"Names: {Name}\nRace: {Race}\nClass: {Class}\nLevel: {Level.CurrentLevel}\nXp: {Level.CurrentXp}\n" +
//                                $"Stats:\n\t{Hp.SumValue}\n\n\t{Damage.SumValue}\n\n\t{Defence.SumValue}";
        public override string Info()
        {
            return base.Info();
        }
    }
}
