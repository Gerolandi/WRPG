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

        private States hp;
        public States Hp
        {
            get { return (hp); }
            set
            {
                hp = value;
                OnPropertyChanged("Hp");
            }
        }

        private States damage;
        public States Damage
        {
            get { return (damage); }
            set
            {
                damage = value;
                OnPropertyChanged("Damage");
            }
        }

        private States defence;
        public States Defence
        {
            get { return (defence); }
            set
            {
                defence = value;
                OnPropertyChanged("Defence");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Charecter charecter;
        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public CharecterInfo(ref Charecter copy) 
        {
            Name = copy.Name;
            Race = copy.Race;
            Class = copy.Class;

            Level = copy.Level;

            Hp = copy.Hp;
            Damage = copy.Damage;
            Defence = copy.Defence;

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
            Type type = typeof(Charecter);
            var tmp = type.GetProperties();
            string output = "";
            foreach ( var prop in tmp )
            {
                if(prop.PropertyType.Name != "States") continue;
                output += $"\n   {prop.Name}: {(prop.GetValue(this) as States)!.SumValue}";
            }
            return output;
        }

    }
}
