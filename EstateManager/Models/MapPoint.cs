using EstateManager.ViewModels;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.Models
{
    class MapPoint : BaseNotifyPropertyChanged
    {

        public double Latitude
        {
            get { return GetProperty<double>(); }
            set { SetProperty<double>(value); }
        }

        public double Longitude
        {
            get { return GetProperty<double>(); }
            set { SetProperty<double>(value); }
        }


        public String Name
        {
            get { return GetProperty<String>(); }
            set { SetProperty<String>(value); }
        }
        public String Description
        {
            get { return GetProperty<String>(); }
            set { SetProperty<String>(value); }
        }

        public Location location { get { return new Location(Latitude, Longitude); } }

    }
}
