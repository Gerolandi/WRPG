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

namespace WRPG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Charecter CurrentCharecter { get; init; }
        private CharecterPage CharPage;
        private Forest ForestLocation;
        public MainWindow(Charecter charecter)
        {
            InitializeComponent();
            CurrentCharecter = charecter;
            CharPage = new CharecterPage(CurrentCharecter);
            ForestLocation = new();
        }
        private void Location_Select(object sender, RoutedEventArgs e)
        {
            switch((sender as Button).Content.ToString())
            {
                case "Charecter":
                    MainFrame.Content = CharPage;
                    break;
                case "Forest":
                    MainFrame.Content = ForestLocation;
                    break;
            }

        }
    }
    
}
namespace HelpTool
{
    public static class DisableNavigation
    {
        public static bool GetDisable(DependencyObject o)
        {
            return (bool)o.GetValue(DisableProperty);
        }
        public static void SetDisable(DependencyObject o, bool value)
        {
            o.SetValue(DisableProperty, value);
        }

        public static readonly DependencyProperty DisableProperty =
            DependencyProperty.RegisterAttached("Disable", typeof(bool), typeof(DisableNavigation),
                                                new PropertyMetadata(false, DisableChanged));



        public static void DisableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (Frame)sender;
            frame.Navigated += DontNavigate;
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        public static void DontNavigate(object sender, NavigationEventArgs e)
        {
            ((Frame)sender).NavigationService.RemoveBackEntry();
        }
    }
}

