using EstateManager.DataAccess;
using EstateManager.Models;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace EstateManager.ViewModels
{
    class DetailsWindowViewModel
    {
        private EstateManagerContext dbContext = EstateManagerContext.Current;
        private Window Parent;

        private int idTransaction;
        public string Title { get; set; }
        public string Description { get; set; }
        public TypeTransaction TransactionType { get; set; }
        public double Price { get; set; }
        public double Fees { get; set; }

        public TypeEstate EstateType { get; set; }
        public int FloorCount { get; set; }
        public int RoomsCount { get; set; }
        public int BathroomCount { get; set; }
        public float Surface { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int FloorNumber { get; set; }
        public int CarbonFootPrint { get; set; }
        public int EnergeticPerformance { get; set; }
        public string City { get; set; }
        public string PubDate { get; set; }
        public Photo MainPhoto { get; set; }

        public DetailsWindowViewModel(int id, Window parent)
        {
            Parent = parent;
            idTransaction = id;
            loadFields(idTransaction);
        }

        public void loadFields(int idEstate)
        {
            Transaction t = dbContext.Transactions.Find(idEstate);
            Estate e = t.Estate;

            EstateType = e.Type;
            FloorCount = e.FloorCount;
            RoomsCount = e.RoomsCount;
            BathroomCount = e.BathroomCount;
            Surface = e.Surface;
            Address = e.Address;
            ZipCode = e.ZipCode;
            FloorNumber = e.FloorNumber;
            CarbonFootPrint = e.CarbonFootPrint;
            EnergeticPerformance = e.EnergeticPerformance;
            City = e.City;
            MainPhoto = e.MainPhoto;

            Title = t.Title;
            Description = t.Description;
            TransactionType = t.Type;
            Price = t.Price;
            Fees = t.Fees;
            PubDate = t.PublicationDate.ToString();
        }


        public ICommand CloseCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickClose);
            }
        }

        public void clickClose()
        {
            Parent.Close();
        }

        public ICommand MinimizeCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickMinimize);
            }
        }

        public void clickMinimize()
        {
            Parent.WindowState = WindowState.Minimized;
        }

        public ICommand MaximizeCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickMaximize);
            }
        }

        public void clickMaximize()
        {
            if (Parent.Width == Screen.PrimaryScreen.WorkingArea.Width && Parent.Height == Screen.PrimaryScreen.WorkingArea.Height)
            {
                Parent.Width = 800;
                Parent.Height = 500;
            }
            else
            {
                Parent.Left = Parent.Top = 0;
                Parent.Width = Screen.PrimaryScreen.WorkingArea.Width;
                Parent.Height = Screen.PrimaryScreen.WorkingArea.Height;
            }
        }
    }
}
