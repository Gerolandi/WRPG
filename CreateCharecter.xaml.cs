using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class CreateCharecter : Window
    {
        public event Action<Charecter> CharecterCreated;
        States Hp = new("Hp");
        States Damage = new("Damage");
        States Defence = new("Defence");
        public CreateCharecter()
        {
            InitializeComponent();
            Hp.AddStat(new Stat("Hp", 0, "Race"));
            Damage.AddStat(new Stat("Damage", 0, "Race"));
            Defence.AddStat(new Stat("Defence", 0, "Race"));

            Hp.AddStat(new Stat("Hp", 0, "Class"));
            Damage.AddStat(new Stat("Damage", 0, "Class"));
            Defence.AddStat(new Stat("Defence", 0, "Class"));
        }
        void Create_Finish(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == null || RaceBox.SelectedItem == null || ClassBox.SelectedItem == null)
            {
                MessageBox.Show("Error parametrs");
                return;
            }
            Charecter tmp = new(NameBox.Text, RaceBox.Text, ClassBox.Text);
            tmp.Hp = Hp;
            tmp.Damage = Damage;
            tmp.Defence = Defence;
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
        void ChangeStat(int hp,int damage,int defence,string source)
        {
            Hp.Update(new Stat("Hp", hp,source));
            Damage.Update(new Stat("Damage", damage,source));
            Defence.Update(new Stat("Defence", defence,source));
            UpdateValue();
        }
        void UpdateValue()
        {
            hp.Text = Hp.SumValue.ToString();
            damage.Text= Damage.SumValue.ToString();
            defence.Text= Defence.SumValue.ToString();
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
    }
}
