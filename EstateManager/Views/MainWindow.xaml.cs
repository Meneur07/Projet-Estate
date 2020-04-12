using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

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
            DataContext = new ViewModels.MainViewModel(this);
            InitializeComponent();
        }

        private void Move(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception) { }
        }
    }
}
