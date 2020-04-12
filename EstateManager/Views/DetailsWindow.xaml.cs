using EstateManager.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace EstateManager.Views
{
    /// <summary>
    /// Logique d'interaction pour DetailsWidow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(int idTransaction)
        {
            DataContext = new DetailsWindowViewModel(idTransaction, this);
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
