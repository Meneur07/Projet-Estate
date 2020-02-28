using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstateManager.Models
{
    public class Photo : ViewModels.BaseNotifyPropertyChanged
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public byte[] Picture
        {
            get { return GetProperty<byte[]>(); }
            set { SetProperty(value); }
        }

        public DateTime ShootingDate
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty(value); }
        }

        public int Reference
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        [ForeignKey(nameof(Reference))]
        public Estate Estate
        {
            get { return GetProperty<Estate>(); }
            set { SetProperty(value); }
        }

        public int PersonId
        {
            get { return GetProperty<int>(); }
            set
            {
                SetProperty(value);
            }
        }


        [ForeignKey(nameof(PersonId))]
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
