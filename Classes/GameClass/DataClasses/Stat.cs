using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WRPG.Classes.GameClass.DataClasses
{
    public class Stat
    {
        public event Action<Stat> StatUpdate;

        public string Name { get; set; }
        public Dictionary<string,float> Values { private get; init; }
        [JsonIgnore]
        public float SumValue { get { return Count(); } }
        public int Level { get; set; }
        public float LevelMultipleir { get; set; }

        public Stat(string name, int level, float levelMultipleir)
        {
            Name = name;
            Level = level;
            LevelMultipleir = levelMultipleir;
            Values = new Dictionary<string,float>();
        }
        public void AddValue(string source, float value)
        {
            Values.Add(source, value);
            StatUpdate?.Invoke(this);
        }
        public void UpdateValue(string source, float value)
        {
            Values[source] = value;
            StatUpdate?.Invoke(this);
        }
        float Count()
        {
            float tmp = 0f;
            foreach (var item in Values)
            {
                tmp += item.Value;
            }
            return tmp * (this.Level * LevelMultipleir + 1);
        }
        public string Info()
        {
            return $"Name: {Name} = {SumValue}";
        }
    }
}
