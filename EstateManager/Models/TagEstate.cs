using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Models
{
    public class TagEstate : ViewModels.BaseNotifyPropertyChanged
    {

       
        public int EstateReference
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        [ForeignKey(nameof(EstateReference))]
        public Estate Estate
        {
            get { return GetProperty<Estate>(); }
            set { SetProperty<Estate>(value); }
        }

        public int TagId
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        [ForeignKey(nameof(TagId))]
        public Tag Tag
        {
            get { return GetProperty<Tag>(); }
            set { SetProperty<Tag>(value); }
        }

    }
}
