using EstateManager.DataAccess;
using EstateManager.Models;
using System;
using System.Windows.Input;
using System.Windows;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EstateManager.ViewModels
{
    class AddTransacViewModel : BaseNotifyPropertyChanged
    {
        private EstateManagerContext dbContext = EstateManagerContext.Current;



        public ObservableCollection<Person> People
        {
            get { return GetProperty<ObservableCollection<Person>>(); }
            set { SetProperty<ObservableCollection<Person>>(value); }
        }

        //public static ObservableCollection<Person> People { get; set; }

        public AddTransacViewModel()
        {
            People = new ObservableCollection<Person>();
            for (int i = 0; i < 7; i++)
            {
                Person toAdd = new Person()
                {
                    FirstName = "Jean" + i,
                    LastName = "Michou"
                };
                dbContext.Add(toAdd);

                People.Add(toAdd);
            }
            dbContext.SaveChanges();
        }
        

        // Transaction part
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public DateTime TransacDate { get; set; }
        public TypeTransaction TransacType { get; set; }
        public double Price { get; set; }
        public double Fees { get; set; }
        public Person Owner { get; set; }
        public Person Client { get; set; }
       


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
        public Person Commercial { get; set; }

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

            Estate estateToBeAdded = new Estate()
            {
                Reference = Reference,
                FloorCount = FloorCount,
                BathroomCount = BathroomCount,
                Surface = Surface,
                Address = Address,
                ZipCode = ZipCode,
                FloorNumber = FloorNumber,
                CarbonFootPrint = CarbonFootPrint,
                EnergeticPerformance = EnergeticPerformance,
                CommercialId = Commercial.Id,
                Photos = new List<Photo>
                {
                    new Photo()
                    {
                        Picture=Photo,
                        PersonId=Commercial.Id
                    }
                }

            };

            Transaction transactionToBeAdded = new Transaction()
            {
                Title = Title,
                Description = Description,
                PublicationDate = PubDate,
                TransactionDate = TransacDate,
                Type = TransacType,
                Price = Price,
                Fees = Fees,
                Reference = estateToBeAdded.Reference,
                OwnerId =Owner.Id,
                ClientId=Client.Id

            };





            dbContext.Add(estateToBeAdded);
            dbContext.SaveChanges();
            dbContext.Add(transactionToBeAdded);
            dbContext.SaveChanges();
            //dbContext.SaveChanges();

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
