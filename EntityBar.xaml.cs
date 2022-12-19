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

namespace WRPG
{
    /// <summary>
    /// Логика взаимодействия для EntityBar.xaml
    /// </summary>
    public partial class EntityBar : Page
    {
        public EntityBar(Entity entity)
        {
            InitializeComponent();
            NameBox.Text = entity.Name;
            HpBar.Maximum = entity.Stats.GetStat("Hp").SumValue;
            StaminaBar.Maximum = entity.Stats.GetStat("Defence").SumValue;
        }
    }
}
