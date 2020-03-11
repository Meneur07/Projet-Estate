using EstateManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EstateManager.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged
    {

        public Page ActualPage
        {
            get { return GetProperty<Page>(); }
            set { SetProperty<Page>(value); }
        }


        public ICommand StatCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickStat);
            }
        }

        void clickStat()
        {
            if (ActualPage?.GetType() != typeof(StatPage))
            {
                ActualPage = new StatPage();
            }
        }

        public ICommand EstateCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickEstate);
            }
        }

        void clickEstate()
        {
            if (ActualPage?.GetType() != typeof(EstatePage))
            {
                ActualPage = new EstatePage();
            }
        }

        public ICommand ClientCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickCustomer);
            }
        }

        void clickCustomer()
        {
            if (ActualPage?.GetType() != typeof(ClientPage))
            {
                ActualPage = new ClientPage();
            }
        }

        public ICommand AppointmentCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickAppointment);
            }
        }

        void clickAppointment()
        {
            if (ActualPage?.GetType() != typeof(AppointmentPage))
            {
                ActualPage = new AppointmentPage();
            }
        }
    }
}
