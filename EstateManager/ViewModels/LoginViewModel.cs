using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace EstateManager.ViewModels
{
    class LoginViewModel : BaseNotifyPropertyChanged
    {

        Views.LoginWindow LoginWindow;

        public String Username
        {
            get { return GetProperty<String>(); }
            set { SetProperty<String>(value); }
        }

        public LoginViewModel(Views.LoginWindow win)
        {
            LoginWindow = win;
        }


        public ICommand Login
        {
            get
            {
                return new Commands.DelegateCommand<PasswordBox>(clickLogin);
            }
        }

        void clickLogin(PasswordBox pbox)
        {
            if (Username == null || pbox.Password == null)
                return;

            var dbContext = DataAccess.EstateManagerContext.Current;
            try
            {

                var loggedUser = dbContext.Users.Where(t => t.Username == Username && t.Password == pbox.Password).First();
                DataAccess.ConnectionContext.ConnectedUser = loggedUser;

                System.Windows.MessageBox.Show("Bonjour " + Username + " !");
                new Views.MainWindow().Show();
                LoginWindow.Close();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Mot de passe ou pseudo incorrect !");
            }
        }


        public ICommand Cancel
        {
            get
            {
                return new Commands.DelegateCommand(clickCancel);
            }
        }

        void clickCancel()
        {
            LoginWindow.Close();
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
            LoginWindow.Close();
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
            LoginWindow.WindowState = WindowState.Minimized;
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
            if (LoginWindow.Width == Screen.PrimaryScreen.WorkingArea.Width && LoginWindow.Height == Screen.PrimaryScreen.WorkingArea.Height)
            {
                LoginWindow.Width = 800;
                LoginWindow.Height = 500;
            }
            else
            {
                LoginWindow.Left = LoginWindow.Top = 0;
                LoginWindow.Width = Screen.PrimaryScreen.WorkingArea.Width;
                LoginWindow.Height = Screen.PrimaryScreen.WorkingArea.Height;
            }
        }
    }
}
