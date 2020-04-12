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
    class AddTransacViewModel : BaseNotifyPropertyChanged
    {
        private EstateManagerContext dbContext = EstateManagerContext.Current;
        private Window Parent;

        public static ObservableCollection<Person> People { get; set; }

        public AddTransacViewModel(Window parent)
        {
            Parent = parent;
            People = new ObservableCollection<Person>(dbContext.Persons.ToList());
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
                System.Windows.MessageBox.Show("Cette référence est déjà attribuée !");
                return;
            }
            if (Commercial == null || Owner == null || Client == null)
            {
                System.Windows.MessageBox.Show("Il faut remplir au minimum toutes les combosBox !");
                return;
            }

            try
            {
                Photo.Person = Commercial;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("Il faut au moins mettre une photo !");
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
