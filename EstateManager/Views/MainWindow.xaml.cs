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
            DataContext = new ViewModels.MainViewModel();
            InitializeComponent();
        }


        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Move(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception) { }
        }

        private void Maximize(object sender, RoutedEventArgs e)
        {
            if (Width == Screen.PrimaryScreen.WorkingArea.Width && Height == Screen.PrimaryScreen.WorkingArea.Height)
            {
                Width = 800;
                Height = 500;
            }
            else
            {
                Left = Top = 0;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Height = Screen.PrimaryScreen.WorkingArea.Height;
            }
        }
    }
}
