using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Models
{
    public class Appointment : ViewModels.BaseNotifyPropertyChanged
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
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

        public DateTime Date
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty<DateTime>(value); }
        }


        public String Reason
        {
            get { return GetProperty<String>(); }
            set { SetProperty<String>(value); }
        }


        public int Person1Id
        {
            get { return GetProperty<int>(); }
            set
            {
                SetProperty(value);
            }
        }


        [ForeignKey(nameof(Person1Id))]
        public Person Person1
        {
            get { return GetProperty<Person>(); }
            set
            {
                SetProperty(value);
            }
        }



        public int Person2Id
        {
            get { return GetProperty<int>(); }
            set
            {
                SetProperty(value);
            }
        }


        [ForeignKey(nameof(Person2Id))]
        public Person Person2
        {
            get { return GetProperty<Person>(); }
            set
            {
                SetProperty(value);
            }
        }

    }
}
