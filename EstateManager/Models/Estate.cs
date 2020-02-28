﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Models
{
    class Estate : ViewModels.BaseNotifyPropertyChanged
    {
<<<<<<< HEAD
        [Key]
        int Reference;

        public TypeEstate Type
        {
            get { return GetProperty<TypeEstate>(); }
            set { SetProperty<TypeEstate>(value); }
        }



        public int FloorCount
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        private int _bathroomCount;

        public int BathroomCount
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }


        public float Surface
        {
            get { return GetProperty<float>(); }
            set { SetProperty<float>(value); }
        }

        public string Address
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }


        public string ZipCode
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }


        public string City
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }


        public int FloorNumber
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        public int CarbonFootPrint
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }



        public int EnergeticPerformance
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        //TODO Ajouter reference à Commercial

=======
        
>>>>>>> 937ee2891d2cb92f48fb650d89fa21c87187a6e0
    }
}
