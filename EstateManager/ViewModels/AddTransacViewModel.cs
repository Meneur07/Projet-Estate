using EstateManager.DataAccess;
using EstateManager.Models;
using System;
using System.Windows.Input;
using System.Windows;
using System.IO;

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
        public string Reference { get; set; }
        public TypeEstate EstateType { get; set; }
        public int FloorCount { get; set; }
        public int BathroomCount { get; set; }
        public float Surface { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int FloorNumber { get; set; }
        public int CarbonFootPrint { get; set; }
        public int EnergeticPerformance { get; set; }
        public int ComercialId { get; set; }
        public byte[] Photo { get; set; }

        public string ImagePath
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
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
            //Ajouter la transac et l'estate dans la BD
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
                ImagePath = dlg.FileName;
            }
        }
    }
}
