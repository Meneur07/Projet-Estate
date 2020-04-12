using EstateManager.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace EstateManager.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged
    {
        private Window Parent;

        public MainViewModel(Window parent)
        {
            Parent = parent;
        }

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

        public ICommand MapCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickMap);
            }
        }

        void clickMap()
        {
            if (ActualPage?.GetType() != typeof(MapPage))
            {
                ActualPage = new MapPage();
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickClose);
            }
        }

        public void clickClose()
        {
            Parent.Close();
        }

        public ICommand MinimizeCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickMinimize);
            }
        }

        public void clickMinimize()
        {
            Parent.WindowState = WindowState.Minimized;
        }

        public ICommand MaximizeCommand
        {
            get
            {
                return new Commands.DelegateCommand(clickMaximize);
            }
        }

        public void clickMaximize()
        {
            if (Parent.Width == Screen.PrimaryScreen.WorkingArea.Width && Parent.Height == Screen.PrimaryScreen.WorkingArea.Height)
            {
                Parent.Width = 800;
                Parent.Height = 500;
            }
            else
            {
                Parent.Left = Parent.Top = 0;
                Parent.Width = Screen.PrimaryScreen.WorkingArea.Width;
                Parent.Height = Screen.PrimaryScreen.WorkingArea.Height;
            }
        }
    }
}
