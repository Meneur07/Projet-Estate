using EstateManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    }
}
