using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRPG.Classes.GameClass.DataClasses
{
    public class Stat
    {
        public string Name { get; set; }
        private float changeableValue;
        public float Value { get { return changeableValue; } set { changeableValue = value; } }
        private float baseValue;
        public string Source { get; }
        public Stat(string name, float value, string source)
        {
            Name = name;
            Value = value;
            baseValue = value;
            Source = source;
        }
        public void AddValue(float value)
        {
            baseValue = Value = value;
        }
        public void Reset()
        {
            changeableValue = baseValue;
        }
        public string GetInfo()
        {
            return $"Name: {Name}\n\tBase value: {baseValue}\n\tCurrent value: {Value}";
        }
    }
}
