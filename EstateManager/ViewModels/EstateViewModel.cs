using EstateManager.DataAccess;
using EstateManager.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EstateManager.ViewModels
{
    class EstateViewModel : BaseNotifyPropertyChanged
    {








        public Models.TypeEstate EstateTypeFilter { get; set; }
        public Models.TypeTransaction TransactionTypeFilter { get; set; }
        public string LocalisationFilter { get; set; }
        public float MaxBudgetFilter { get; set; }
        public float MinSurfaceFilter { get; set; }
        public int FloorsCountFilter { get; set; }
        public int FloorNumberFilter { get; set; }
        public int RoomsCountFilter { get; set; }
        public int BathroomsCountFilter { get; set; }


        public bool ShouldApplyFilter
        {
            get { return GetProperty<bool>(); }
            set {
                SetProperty<bool>(value);
                    updateContent();
                    }
        }






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
            var request = dbContext.Transactions.Include(b => b.Estate).ThenInclude(est => est.Photos);
            List<Transaction> translist = request.ToList();
            if (ShouldApplyFilter)
            {

                translist = request.Where(t => t.Price < MaxBudgetFilter || MaxBudgetFilter == 0).
                Where(b => b.Estate.Surface > MinSurfaceFilter || MinSurfaceFilter == 0).
                Where(t => t.Type == TransactionTypeFilter && t.Estate.Type == EstateTypeFilter).
                Where(t => t.Estate.FloorCount == FloorsCountFilter || FloorsCountFilter == 0).
                Where(t => t.Estate.RoomsCount == RoomsCountFilter || RoomsCountFilter == 0).
                Where(t => t.Estate.BathroomCount == BathroomsCountFilter || BathroomsCountFilter == 0).
                Where(t => t.Estate.FloorNumber == FloorNumberFilter || FloorNumberFilter == 0).ToList();
            }




            foreach (var trans in translist)
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



        public ICommand ApplyFilterCommand
        {
            get
            {
                return new Commands.DelegateCommand(ApplyFilters);
            }
        }

        void ApplyFilters()
        {
            windowFilter.Close();
        }

        public ICommand FilterCommand
        {
            get
            {
                return new Commands.DelegateCommand(ClickFilter);
            }
        }

        Views.FilterPopup windowFilter;
        void ClickFilter()
        {
            windowFilter = new Views.FilterPopup
            {
                DataContext = this
            };
            windowFilter.ShowDialog();
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
            ModifyTransaction mt = new ModifyTransaction(idEstate);
            mt.ShowDialog();
            updateContent();
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
