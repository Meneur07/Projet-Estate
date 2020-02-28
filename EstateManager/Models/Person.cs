using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Models
{
    class Person : ViewModels.BaseNotifyPropertyChanged
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }



        public string LastName
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }


        public string FirstName
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }


        public string CellPhone
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }


        public string Mail
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
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




    }
}
