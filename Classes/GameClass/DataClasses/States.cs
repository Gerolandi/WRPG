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
        public Dictionary<string,Stat> Stats { private get; init; }
        public event Action<Stat> StatUpdate;
        
        public States() { Stats = new(); }

        public Stat GetStat(string name) { return Stats[name]; }

        public void AddStat(Stat stat)
        {
            Stats.Add(stat.Name, stat);
            stat.StatUpdate += Stat_StatUpdate;
        }

        private void Stat_StatUpdate(Stat obj)
        {
            StatUpdate?.Invoke(obj);
        }

        public void RemoveStat(string name) { Stats.Remove(name); }

        public void Update(Stat stat)
        {
            Stats[stat.Name] = stat;
        }
        public void LevelUpdate(int level)
        {
            foreach(var i in Stats)
            {
                i.Value.Level = level;
            }
        }

    }
}
