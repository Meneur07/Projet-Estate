using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Models
{
    public class Estate : ViewModels.BaseNotifyPropertyChanged
    {

        [Key]
        public int Reference
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }


        public TypeEstate Type
        {
            get { return GetProperty<TypeEstate>(); }
            set { SetProperty<TypeEstate>(value); }
        }




        public virtual ICollection<Photo> Photos
        {
            get { return GetProperty<ICollection<Photo>>(); }
            set { SetProperty<ICollection<Photo>>(value); }
        }



        public int FloorCount
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

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


        public int CommercialId
        {
            get { return GetProperty<int>(); }
            set
            {
                SetProperty(value);
            }
        }


        [ForeignKey(nameof(CommercialId))]
        public Person Person
        {
            get { return GetProperty<Person>(); }
            set
            {
                SetProperty(value);
            }
        }


    }
}
