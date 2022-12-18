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
    public class CharecterInfo : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return (name); }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string race;
        public string Race
        {
            get { return (race); }
            set
            {
                race = value;
                OnPropertyChanged("Race");
            }
        }

        private string @class;
        public string Class
        {
            get { return (@class); }
            set
            {
                @class = value;
                OnPropertyChanged("Class");
            }
        }

        private Level level;
        public Level Level
        {
            get { return (level); }
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }

        private States stats;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Charecter charecter;
        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public CharecterInfo(ref Charecter copy) 
        {
            Name = copy.Name;
            Race = copy.Race;
            Class = copy.Class;

            Level = copy.Level;

            stats = copy.Stats

            charecter = copy;

            copy.Level.XpValueChanged += Level_XpValueChanged;
        }

        private void Level_XpValueChanged()
        {
            OnPropertyChanged("Level");
        }

        public string GetAllInfo()
        {
            return $"Name: {Name}\nRace: {Race}\nClass: {Class}\n" +
                   $"Stats:" + GetAllStat();
        }
        private string GetAllStat() 
        { 
            Type type = typeof(States);
            var tmp = type.GetProperties();
            string output = "";
            foreach ( var prop in tmp )
            {
                if(prop.PropertyType.Name != "States") continue;
                output += $"\n   {prop.Name}: {(prop.GetValue(this.) as States)!.SumValue}";
            }
            return output;
        }

    }
}
