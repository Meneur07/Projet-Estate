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

namespace EstateManager.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 
    // Dans la console nuget : Add-Migration Initial
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new ViewModels.MainViewModel();
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }



        private void Ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Maximize(object sender, MouseButtonEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
            
        }

        private void Minimize(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
