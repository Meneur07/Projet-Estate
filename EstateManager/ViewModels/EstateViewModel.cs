using EstateManager.DataAccess;
using EstateManager.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EstateManager.ViewModels
{
    class EstateViewModel : BaseNotifyPropertyChanged
    {


        public ObservableCollection<Transaction> Transactions
        {
            get { return GetProperty<ObservableCollection<Transaction>>(); }
            set { SetProperty<ObservableCollection<Transaction>>(value); }
        }


        private EstateManagerContext dbContext;

        public EstateViewModel()
        {
            Transactions = new ObservableCollection<Transaction>();
            dbContext = EstateManagerContext.Current;

            updateContent();
        }


        void updateContent()
        {
            Transactions.Clear();
            var transList = dbContext.Transactions.Include(b => b.Estate).ThenInclude(est => est.Photos).ToList();
            foreach (var trans in transList)
            {
                Transactions.Add(trans);
            }
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
            updateContent();
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Commands.DelegateCommand<int>(clickDelete);
            }
        }

        void clickDelete(int idEstate)
        {
            dbContext.Transactions.Remove(dbContext.Transactions.Where(t => t.Reference == idEstate).FirstOrDefault());
            dbContext.Estates.Remove(dbContext.Estates.Find(idEstate));
            dbContext.SaveChanges();
            updateContent();
        }

        public ICommand ModifyCommand
        {
            get
            {
                return new Commands.DelegateCommand<int>(clickModify);
            }
        }

        void clickModify(int idEstate)
        {
            MessageBox.Show("Je veux modify l'estate avec l'id : " + idEstate);
        }

        public ICommand DetailsCommand
        {
            get
            {
                return new Commands.DelegateCommand<int>(clickItem);
            }
        }

        void clickItem(int idTransac)
        {
            MessageBox.Show(idTransac.ToString());
        }
    }
}
