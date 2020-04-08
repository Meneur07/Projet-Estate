using EstateManager.DataAccess;
using EstateManager.Models;
using System;
using System.Windows.Input;
using System.Windows;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EstateManager.ViewModels
{
    class AddTransacViewModel : BaseNotifyPropertyChanged
    {
        private EstateManagerContext dbContext = EstateManagerContext.Current;
        private Window Parent;

        public static ObservableCollection<Person> People { get; set; }
        Random r = new Random();

        private Person GeneratePerson()
        {
            string[] arrayNames = { "Jean", "Paule", "Pierre", "Jacqueline", "Michel", "David", "Léo", "Claudette", "Cloé", "Gertrude" };

            string firstName = arrayNames[r.Next(arrayNames.Length)];
            string lastName = arrayNames[r.Next(arrayNames.Length)];
            string cellPhone = "";
            string mail = firstName + "." + lastName + "@truc.fr";
            string Adress = r.Next(0, 200) + " rue du " + lastName;
            string ZipCode = "";
            string city = lastName + firstName;

            for (int j = 0; j < 5; j++)
            {
                ZipCode += r.Next(0, 10);
            }
            for (int j = 0; j < 10; j++)
            {
                cellPhone += r.Next(0, 10);
            }


            return new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                ZipCode = ZipCode,
                Address = Adress,
                City = city,
                CellPhone = cellPhone
            };


        }
        public AddTransacViewModel(Window parent)
        {
            Parent = parent;
            People = new ObservableCollection<Person>(dbContext.Persons.ToList());
            if (People.Count != 0)
                return;

            for (int i = 0; i < 10; i++)
            {
                Person toAdd = GeneratePerson();
                dbContext.Add(toAdd);
            }
            MessageBox.Show("J'ai généré 10 personnes aléatoirement !");
            dbContext.SaveChanges();
        }


        // Transaction part
        public string Title { get; set; }
        public string Description { get; set; }
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
        public int RoomsCount { get; set; }
        public int BathroomCount { get; set; }
        public float Surface { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int FloorNumber { get; set; }
        public int CarbonFootPrint { get; set; }
        public int EnergeticPerformance { get; set; }
        public string City { get; set; }
        public Person Commercial { get; set; }

        public Photo Photo
        {
            get { return GetProperty<Photo>(); }
            set { SetProperty<Photo>(value); }
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
            Estate res = dbContext.Estates.Find(Reference);
            if (res != null || Reference == 0)
            {
                MessageBox.Show("Cette référence est déjà attribuée !");
                return;
            }
            if (Commercial == null || Owner == null || Client == null)
            {
                MessageBox.Show("Il faut remplir au minimum toutes les combosBox !");
                return;
            }

            try
            {
                Photo.Person = Commercial;
            }
            catch (Exception e)
            {
                MessageBox.Show("Il faut au moins mettre une photo !");
                return;
            }

            Estate estateToBeAdded = new Estate()
            {
                Reference = Reference,
                FloorCount = FloorCount,
                RoomsCount = RoomsCount,
                BathroomCount = BathroomCount,
                Surface = Surface,
                Address = Address,
                ZipCode = ZipCode,
                City = City,
                FloorNumber = FloorNumber,
                CarbonFootPrint = CarbonFootPrint,
                Type = EstateType,
                EnergeticPerformance = EnergeticPerformance,
                CommercialId = Commercial.Id,
                Photos = new List<Photo>
                {
                    Photo
                }
            };

            Transaction transactionToBeAdded = new Transaction()
            {
                Title = Title,
                Description = Description,
                PublicationDate = DateTime.Now.AddMonths(-1),
                Type = TransacType,
                Price = Price,
                Fees = Fees,
                Estate = estateToBeAdded,
                Owner = Owner,
                Client = Client

            };


            dbContext.Estates.Add(estateToBeAdded);
            dbContext.Transactions.Add(transactionToBeAdded);
            dbContext.SaveChanges();

            Parent.Close();
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
                Photo = new Photo();
                Photo.Picture = ImageToByteArray(Image.FromFile(imagePath));
                Photo.ShootingDate = File.GetCreationTime(imagePath);

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
