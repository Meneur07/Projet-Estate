using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstateManager.Models
{
    class Photo : ViewModels.BaseNotifyPropertyChanged
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get {return GetProperty<int>(); }
                        set { SetProperty(value); } }

        public byte[] Image { get { return GetProperty<byte[]>(); }
                              set { SetProperty(value); } }
        
        public DateTime ShootingDate { get { return GetProperty<DateTime>(); }
                                       set { SetProperty(value); } }

        public int Reference { get; set; }

        [ForeignKey(nameof(Reference))]
        public Estate Estate { get; set; }

        public int PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }
    }
}
