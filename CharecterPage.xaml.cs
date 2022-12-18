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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WRPG.Classes;
using WRPG.Classes.GameClass.DataClasses;

namespace WRPG
{
    /// <summary>
    /// Логика взаимодействия для Charecter.xaml
    /// </summary>
    public partial class CharecterPage : Page
    {
        Inventory<Image> inv = new(new Image() { Source = new BitmapImage(new Uri("pack://application:,,,/empty.png")) },18);
        List<Image> images = new List<Image>();
        public CharecterInfo info { get; set; }
        //public Charecter Charecter { get; set; }
        public CharecterPage(Charecter charecter)
        {
            InitializeComponent();
            info = new(ref charecter);
            DataContext = info;
            //info.Charecter.StatChange += (string stat) => CharecterInformation.Text = info.GetAllInfo();
            //CharecterInformation.Text = info.GetAllInfo();
            ////MessageBox.Show(info.Charecter.Info());
            InventoryCellGenerete();
            //LevelConfigure();
            //info.Charecter.ReStat();
            //Test.Content = new EntityBar(info.Charecter);
        }

        private void LevelConfigure()
        {
            //LevelNumber.Text = info.Charecter.Level.CurrentLevel.ToString();
            //LevelBar.Minimum = info.Charecter.Level.XpForPastLevel;
            //LevelBar.Maximum = info.Charecter.Level.XpForNewLevel;
            //LevelBar.Value = info.Charecter.Level.CurrentXp;
            //LevelCount.Text = info.Charecter.Level.CurrentXp + "/" + info.Charecter.Level.XpForNewLevel;
                
            
        }
        private void InventoryCellGenerete()
        {
            var tmp = inv.GetAll();
            for (int i = 0; i < 18; i++)
            {
                Image img = new Image();
                img.Stretch = Stretch.Fill;
                img.Width = 70;
                img.Height = 70;
                inventory.Children.Add(img);
                images.Add(img);
                img.Source = tmp[i].Source;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            info.charecter.Level.XdAdd(10);
            //LevelConfigure();
            //if (((Button)sender).Content.ToString() == "Add")a
            //{
            //    inv.Put("pack://application:,,,/1.PNG");
            //    return;
            //}
            //else
            //{
            //    string[] tmp = inv.GetAll();
            //    for (int i = 0; i < images.Count; i++)
            //    {
            //        try
            //        {
            //            if (tmp[i] == null) continue;
            //            images[i].Source = new BitmapImage(new Uri(tmp[i]));
            //        }catch(Exception) { continue; }

            //    }
            //}
        }
    }
}
