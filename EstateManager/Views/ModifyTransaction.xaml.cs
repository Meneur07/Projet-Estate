using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace EstateManager.Views
{
    /// <summary>
    /// Logique d'interaction pour AddTransaction.xaml
    /// </summary>
    public partial class ModifyTransaction : Window
    {
        public ModifyTransaction(int idEstate)
        {
            DataContext = new ViewModels.ModifyTransacViewModel(this, idEstate);
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