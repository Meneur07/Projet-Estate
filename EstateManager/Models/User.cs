using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Models
{
    public class User : ViewModels.BaseNotifyPropertyChanged
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }



        public String Password
        {
            get { return GetProperty<String>(); }
            set { SetProperty<String>(value); }
        }


        public TypeUser Type
        {
            get { return GetProperty<TypeUser>(); }
            set { SetProperty<TypeUser>(value); }
        }


        public String Username
        {
            get { return GetProperty<String>(); }
            set { SetProperty<String>(value); }
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
