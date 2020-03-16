using EstateManager.DataAccess;
using EstateManager.Models;
using System;
using System.Windows.Input;
using System.Windows;
using System.IO;
using System.Drawing;

namespace EstateManager.ViewModels
{
    class AddTransacViewModel : BaseNotifyPropertyChanged
    {
        private EstateManagerContext dbContext = EstateManagerContext.Current;

        // Transaction part
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public DateTime TransacDate { get; set; }
        public TypeTransaction TransacType { get; set; }
        public double Price { get; set; }
        public double Fees { get; set; }
        public int PropId { get; set; }
        public int CliId { get; set; }


        //Estate part
        public int Reference
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        public TypeEstate EstateType { get; set; }
        public int FloorCount { get; set; }
        public int BathroomCount { get; set; }
        public float Surface { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int FloorNumber { get; set; }
        public int CarbonFootPrint { get; set; }
        public int EnergeticPerformance { get; set; }
        public int CommercialId { get; set; }

        public byte[] Photo
        {
            get { return GetProperty<byte[]>(); }
            set { SetProperty<byte[]>(value); }
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


            Transaction transactionToBeAdded = new Transaction()
            {
                Title = Title,
                Description = Description,
                PublicationDate = PubDate,
                TransactionDate = TransacDate,
                Type = TransacType,
                Price = Price,
                Fees = Fees,
                OwnerId=PropId,
                ClientId=CliId

            };

            Estate estateToBeAdded = new Estate()
            {
                Reference = Reference,
                FloorCount = FloorCount,
                BathroomCount = BathroomCount,
                Surface = Surface,
                Address=Address,
                ZipCode = ZipCode,
                FloorNumber=FloorNumber,
                CarbonFootPrint = CarbonFootPrint,
                EnergeticPerformance = EnergeticPerformance,
                CommercialId = CommercialId,
                Picture = Photo

            };
            dbContext.Add(estateToBeAdded);
            dbContext.Add(transactionToBeAdded);
            dbContext.SaveChanges();

            //Ajouter la transaction et l'estate dans la BD
        }

        public ICommand PickImageCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickPickImage);
            }
        }

        void clickPickImage()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string imagePath = dlg.FileName;
                Photo = ImageToByteArray(Image.FromFile(imagePath));
            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
