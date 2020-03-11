using EstateManager.ViewModels;
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
    /// Logique d'interaction pour EstatePage.xaml
    /// </summary>
    public partial class EstatePage : Page
    {
        public EstatePage()
        {
            DataContext = new EstateViewModel();
            InitializeComponent();
        }
    }
}
