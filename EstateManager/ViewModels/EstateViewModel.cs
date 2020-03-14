using EstateManager.DataAccess;
using EstateManager.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EstateManager.ViewModels
{
    class EstateViewModel
    {

        public ObservableCollection<Estate> Estates { get; set; }
        private EstateManagerContext dbContext;

        public EstateViewModel()
        {
            Estates = new ObservableCollection<Estate>();
            dbContext = EstateManagerContext.Current;
        }

        public ICommand AddCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickAdd);
            }
        }

        void clickAdd()
        {
            var windowAdd = new Views.AddTransaction();
            windowAdd.ShowDialog();
        }
    }
}
