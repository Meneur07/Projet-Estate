using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace EstateManager.Views
{
    /// <summary>
    /// Logique d'interaction pour AddTransaction.xaml
    /// </summary>
    public partial class AddTransaction : Window
    {
        public AddTransaction()
        {
            DataContext = new ViewModels.AddTransacViewModel(this);
            InitializeComponent();
        }

        private void Move(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch(Exception) { }
        }
    }
}