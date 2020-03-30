using EstateManager.DataAccess;
using EstateManager.Models;

namespace EstateManager.ViewModels
{
    class DetailsWindowViewModel
    {
        private EstateManagerContext dbContext = EstateManagerContext.Current;

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

        public DetailsWindowViewModel(int id)
        {
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
    }
}
