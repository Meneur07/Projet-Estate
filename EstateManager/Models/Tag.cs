using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Models
{
    public class Tag : ViewModels.BaseNotifyPropertyChanged

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
