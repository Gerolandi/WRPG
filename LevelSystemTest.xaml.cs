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
using WRPG.Classes.GameClass.DataClasses;

namespace WRPG
{
    /// <summary>
    /// Логика взаимодействия для LevelSystemTest.xaml
    /// </summary>
    public partial class LevelSystemTest : Window
    {
        Level level = new(1,0);
        public LevelSystemTest()
        {
            InitializeComponent();
            XpChange.ValueChanged += Exp_ValueChanged;
            LevelBar.Minimum = XpChange.Minimum = level.XpForPastLevel;
            LevelBar.Maximum = XpChange.Maximum = level.XpForNewLevel;
            
        }

        private void Exp_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LevelBar.Value = e.NewValue;
        }
    }
}
