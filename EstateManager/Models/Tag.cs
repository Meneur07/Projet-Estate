using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Models
{
<<<<<<< HEAD
    public class Tag
=======
    class Tag : ViewModels.BaseNotifyPropertyChanged
>>>>>>> a3b1acba4434c94d5c5ff548e9a7580731a9d1af
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }


        public string Label
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

    }
}
