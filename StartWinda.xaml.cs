using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    /// Логика взаимодействия для StartWinda.xaml
    /// </summary>
    public partial class StartWinda : Window
    {
        public string Namenka { get; set; } = "Niet";
        public Charecter? chare = new();
        public StartWinda()
        {
            InitializeComponent();
            string tmp = "";
            for(int i = 0; i < 100; i++)
            {
                tmp += i+" "+Level(i).ToString() + "\n";
            }
            //MessageBox.Show($"New level: {lvl.XpForNewLevel}\nPast level: {lvl.XpForPastLevel}");
            new FightWindow().Show();
        }
        private double NextLevel(int level)
        {
            return Math.Round((5 * (Math.Pow(level,3)) / 5));
        }
        double Level(int level)
        {
            double exponent = 1.3;
            double baseXp = 100;
            return Math.Floor(baseXp * Math.Pow(level, exponent));
        }
        private void Start_Event(object sender,RoutedEventArgs e)
        {
            CharGrid.Visibility = Visibility.Visible;

            Save1.Content = new Save(1).ToString();
            Save2.Content = new Save(2).ToString();
            Save3.Content = new Save(3).ToString();
        }
        private void Setting_Event(object sender, RoutedEventArgs e) 
        {
        }
        private void Exit_Event(object sender, RoutedEventArgs e) { }
        private void Charecter_Select(object sender, RoutedEventArgs e)
        {
            var tmp = (Button)sender;
            if (tmp.Content.ToString() == "Create charecter")
            {                
                var tmpek = new CreateCharecter();
                tmpek.CharecterCreated += CreateOver;
                tmpek.ShowDialog();
                void CreateOver(Charecter charecter)
                {
                    chare = charecter;
                    File.WriteAllText("D:\\Formy\\WRPG\\WRPG\\Assets\\Saves\\Charecter" + tmp.Name[tmp.Name.Length - 1] + ".json"
                                  , JsonSerializer.Serialize<Charecter>(charecter));
                }                
            }
            else
            {
                chare = JsonSerializer.Deserialize<Charecter>(File.ReadAllText(@"D:\Formy\WRPG\WRPG\Assets\Saves\Charecter" + tmp.Name[tmp.Name.Length - 1] + ".json"));
                new MainWindow(chare!).Show();

                this.Close();
            }
        }
    }
}
