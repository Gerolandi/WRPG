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

namespace WRPG.Windows
{
    /// <summary>
    /// Логика взаимодействия для FightWindow.xaml
    /// </summary>
    public partial class FightWindow : Window
    {
         
        public FightWindow()
        {
            InitializeComponent();
            CharecterFrame.Content = new EntityBar(new Charecter("Dimas","Orc","Mage"));
            EnemyFrame.Content = new EntityBar(new Charecter("Zombie", "Zombie", "Warrior"));
        }
    }
}
