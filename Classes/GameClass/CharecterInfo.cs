using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using WRPG.Classes.GameClass.DataClasses;

namespace WRPG.Classes
{
    public class CharecterInfo
    {
        public Charecter Charecter { get; init; }
        public CharecterInfo(Charecter charecter) { Charecter = charecter; }
        public string GetAllInfo()
        {
            return $"Name: {Charecter.Name}\nRace: {Charecter.Race}\nClass: {Charecter.Class}\n" +
                   $"Stats:" + GetAllStat();
        }
        private string GetAllStat() 
        { 
            Type type = typeof(Charecter);
            var tmp = type.GetProperties();
            string output = "";
            foreach ( var prop in tmp )
            {
                if(prop.PropertyType.Name != "States") continue;
                output += $"\n   {prop.Name}: {(prop.GetValue(Charecter) as States)!.SumValue}";
            }
            return output;
        }
    }
}
