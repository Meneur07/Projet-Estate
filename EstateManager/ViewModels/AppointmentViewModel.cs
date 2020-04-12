using EstateManager.Models;
using Geocoding;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocoding.Microsoft;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Input;
using EstateManager.DataAccess;

namespace EstateManager.ViewModels
{
    class AppointmentViewModel
    {

        public ObservableCollection<Appointment> Appointments { get; set; }
        private EstateManagerContext dbContext { get; set; }

        public AppointmentViewModel()
        {
            dbContext = EstateManagerContext.Current;
            Appointments = new ObservableCollection<Appointment>();
            loadAppointments(DateTime.Now);
        }

        public void loadAppointments(DateTime? date)
        {
            if (date == null)
            {
                return;
            }
            DateTime temp = (DateTime)date;
            Appointments.Clear();
            List<Appointment> result = dbContext.Appointments.Where(a => a.Date.Day == temp.Day).ToList();
            foreach (Appointment a in result)
            {
                Appointments.Add(a);
            }
        }

        /*public ICommand clickDayCommand
        {
            get
            {
                return new Commands.DelegateCommand<DateTime>(clickDay);
            }
        }

        void clickDay(DateTime date)
        {
            loadAppointments(date);
        }*/



    }
}
