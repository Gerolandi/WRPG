using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace WRPG.Classes.GameClass.DataClasses
{
    public class States
    {
        public string Name { get; set; }
        [JsonIgnore]
        public float SumValue { get { return ReStat(); } }
        public int Level { get; set; }
        public float LevelMultiplier { get; set; }
        public List<Stat> stats { get; set; }

        private float ReStat()
        {
            float tmp = 0;
            foreach (var i in stats)
            {
                tmp += i.Value;
            }
            tmp = tmp * (1+(LevelMultiplier * Level));
            return tmp;
        }

        public States(string name,float levelScale,int level)
        {
            Name = name;
            LevelMultiplier = levelScale;
            this.Level = level;
            stats = new List<Stat>();
        }
        public States() { Name = "None"; stats = new(); }
        public Stat GetStat(string source) => stats.Find((e) => e.Source == source)!;
        public void AddStat(Stat stat)
        {
            if (stat.Name != Name) { throw new Exception("Error add stat: Name stat not equals"); }
            stats.Add(stat);
        }
        public void Update(Stat stat)
        {
            for (int i = 0; i < stats.Count; i++)
            {
                if (stats[i].Source == stat.Source)
                {
                    stats[i] = stat;
                    break;
                }
            }
        }

    }
}
