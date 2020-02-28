using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstateManager.Models
{
    public class Transaction : ViewModels.BaseNotifyPropertyChanged
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetProperty<int>(); }
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

        public string Title
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        public string Description
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        public DateTime PublicationDate
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty(value); }
        }

        public DateTime TransactionDate
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty(value); }
        }

        public TypeTransaction Type
        {
            get { return GetProperty<TypeTransaction>(); }
            set { SetProperty(value); }
        }

        public double Price
        {
            get { return GetProperty<double>(); }
            set { SetProperty(value); }
        }

        public double Fees
        {
            get { return GetProperty<double>(); }
            set { SetProperty(value); }
        }

        public int OwnerId
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        [ForeignKey(nameof(OwnerId))]
        public Person Owner
        {
            get { return GetProperty<Person>(); }
            set { SetProperty(value); }
        }

        public int ClientId
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        [ForeignKey(nameof(ClientId))]
        public Person Client
        {
            get { return GetProperty<Person>(); }
            set { SetProperty(value); }
        }

    }
}
