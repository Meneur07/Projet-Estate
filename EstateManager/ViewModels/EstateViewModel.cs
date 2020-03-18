using EstateManager.DataAccess;
using EstateManager.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EstateManager.ViewModels
{
    class EstateViewModel
    {

        public ObservableCollection<Transaction> Transactions { get; set; }
        private EstateManagerContext dbContext;

        public EstateViewModel()
        {
            Transactions = new ObservableCollection<Transaction>();
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

        public ICommand DeleteCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickDelete);
            }
        }

        void clickDelete()
        {
            MessageBox.Show("Je veux delete");
        }

        public ICommand ModifyCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickModify);
            }
        }

        void clickModify()
        {
            MessageBox.Show("Je veux modify");
        }
    }
}
