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
using System.Windows.Forms;

namespace EstateManager.ViewModels
{
    class ModifyTransacViewModel : BaseNotifyPropertyChanged
    {
        private EstateManagerContext dbContext = EstateManagerContext.Current;
        private Window Parent;
        private Estate estateToModify;
        private Transaction transactionToModify;

        public static ObservableCollection<Person> People { get; set; }
        Random r = new Random();

        // Transaction part
        public string Title { get; set; }
        public string Description { get; set; }
        public TypeTransaction TransacType { get; set; }
        public double Price { get; set; }
        public double Fees { get; set; }
        public Person Owner { get; set; }
        public Person Client { get; set; }


        //Estate part
        public int Reference { get; set; }
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

        public ModifyTransacViewModel(Window parent, int idEstate)
        {
            Parent = parent;
            Reference = idEstate;
            estateToModify = dbContext.Estates.Find(Reference);
            People = new ObservableCollection<Person>(dbContext.Persons.ToList());
            loadFields(idEstate);
            if (People.Count != 0)
                return;

            for (int i = 0; i < 10; i++)
            {
                Person toAdd = GeneratePerson();
                dbContext.Add(toAdd);
            }
            dbContext.SaveChanges();
            loadFields(idEstate);
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
            mergeTextFieldsWithObjectsToUpdate();
            dbContext.Estates.Update(estateToModify);
            dbContext.Transactions.Update(transactionToModify);
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

        public void loadFields(int idEstate)
        {
            //Chargement des infos pour l'estate
            estateToModify = dbContext.Estates.Find(Reference);
            Reference = idEstate;
            EstateType = estateToModify.Type;
            FloorCount = estateToModify.FloorCount;
            RoomsCount = estateToModify.RoomsCount;
            BathroomCount = estateToModify.BathroomCount;
            Surface = estateToModify.Surface;
            Address = estateToModify.Address;
            ZipCode = estateToModify.ZipCode;
            FloorNumber = estateToModify.FloorNumber;
            CarbonFootPrint = estateToModify.CarbonFootPrint;
            EnergeticPerformance = estateToModify.EnergeticPerformance;
            City = estateToModify.City;
            Commercial = People.Where(p => p.Id == estateToModify.CommercialId).FirstOrDefault();
            Photo = estateToModify.MainPhoto;

            //Chargement des infos pour la transaction
            transactionToModify = dbContext.Transactions.Where(t => t.Estate == estateToModify).FirstOrDefault();
            Title = transactionToModify.Title;
            Description = transactionToModify.Description;
            TransacType = transactionToModify.Type;
            Price = transactionToModify.Price;
            Fees = transactionToModify.Fees;
            Owner = People.Where(p => p.Id == transactionToModify.OwnerId).FirstOrDefault();
            Client = People.Where(p => p.Id == transactionToModify.ClientId).FirstOrDefault();
        }

        public void mergeTextFieldsWithObjectsToUpdate()
        {
            estateToModify.FloorCount = FloorCount;
            estateToModify.RoomsCount = RoomsCount;
            estateToModify.BathroomCount = BathroomCount;
            estateToModify.Surface = Surface;
            estateToModify.Address = Address;
            estateToModify.ZipCode = ZipCode;
            estateToModify.City = City;
            estateToModify.FloorNumber = FloorNumber;
            estateToModify.CarbonFootPrint = CarbonFootPrint;
            estateToModify.Type = EstateType;
            estateToModify.EnergeticPerformance = EnergeticPerformance;
            estateToModify.CommercialId = Commercial.Id;
            estateToModify.Photos = new List<Photo> { Photo };


            transactionToModify.Title = Title;
            transactionToModify.Description = Description;
            transactionToModify.Type = TransacType;
            transactionToModify.Price = Price;
            transactionToModify.Fees = Fees;
            transactionToModify.Estate = estateToModify;
            transactionToModify.Owner = Owner;
            transactionToModify.Client = Client;

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
