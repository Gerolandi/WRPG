using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WRPG.Classes;
using WRPG.Classes.GameClass.DataClasses;

namespace WRPG
{
    /// <summary>
    /// Логика взаимодействия для CreateCharecter.xaml
    /// </summary>
    public partial class CreateCharecter : Window, INotifyPropertyChanged
    {
        public event Action<Charecter> CharecterCreated;
        public event PropertyChangedEventHandler? PropertyChanged;

        States stats= new States();
        public float Hp { get { return stats.GetStat("Hp").SumValue; } }
        public float Damage { get { return stats.GetStat("Damage").SumValue; } }
        public float Defence { get { return stats.GetStat("Defence").SumValue; } }
        public CreateCharecter()
        {
            InitializeComponent();
            stats.AddStat(new Stat("Hp", 1, 0.2f));
            stats.AddStat(new Stat("Damage", 1, 0.2f));
            stats.AddStat(new Stat("Defence", 1, 0.2f));

            stats.GetStat("Hp").AddValue("Race", 0);
            stats.GetStat("Damage").AddValue("Race", 0);
            stats.GetStat("Defence").AddValue("Race", 0); 

            stats.GetStat("Hp").AddValue("Class", 0);
            stats.GetStat("Damage").AddValue("Class", 0);
            stats.GetStat("Defence").AddValue("Class", 0);

            DataContext = this;

            stats.StatUpdate += Stats_StatUpdate;

        }

        private void Stats_StatUpdate(Stat obj)
        {
            OnPropertyChanged(obj.Name);
        }

        void Create_Finish(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == null || RaceBox.SelectedItem == null || ClassBox.SelectedItem == null)
            {
                MessageBox.Show("Error parametrs");
                return;
            }
            Charecter tmp = new(NameBox.Text, RaceBox.Text, ClassBox.Text) { Stats = stats};
            CharecterCreated.Invoke(tmp);
            Close();
        }

        private void RaceBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tmp = (RaceBox.SelectedItem as ComboBoxItem).Content.ToString();
            switch(tmp)
            {
                case "Human":
                    ChangeStat(100,10,10,"Race");
                    break;
                case "Orc":
                    ChangeStat(125,17,0,"Race");
                    break;
                case "Elf":
                    ChangeStat(90,13,7,"Race");
                    break;
                default: break;
            }
        }

        private void ClassBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tmp = (ClassBox.SelectedItem as ComboBoxItem).Content.ToString();
            switch (tmp)
            {
                case "Mage":
                    ChangeStat(-20, 10, -15,"Class");
                    break;
                case "Warrior":
                    ChangeStat(25, 5, -5,"Class");
                    break;
                case "Archer":
                    ChangeStat(-10, 7, -10,"Class");
                    break;
                default: break;
            }
        }

        void ChangeStat(int hp, int damage, int defence, string source)
        {
            stats.GetStat("Hp").UpdateValue(source, hp);
            stats.GetStat("Damage").UpdateValue(source, damage);
            stats.GetStat("Defence").UpdateValue(source, defence);
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
