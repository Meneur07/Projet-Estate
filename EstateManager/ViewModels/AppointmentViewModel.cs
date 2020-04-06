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

namespace EstateManager.ViewModels
{

    

    class AppointmentViewModel : BaseNotifyPropertyChanged
    {



        public ObservableCollection<MapPoint> OcMapPoints
        {
            get { return GetProperty<ObservableCollection<MapPoint>>(); }
            set { SetProperty<ObservableCollection<MapPoint>>(value); }
        }


        public AppointmentViewModel()
        {
            

            var dbContext = DataAccess.EstateManagerContext.Current;
            OcMapPoints = new ObservableCollection<MapPoint>();
            var locationList = dbContext.Transactions.Include(b => b.Estate).ToList();
            Task t = Task.Run(() => PlacePointsAsync(locationList));
            t.Wait();
        }

        async Task PlacePointsAsync(List<Transaction> list)
        {

            IGeocoder geocoder = new BingMapsGeocoder("2nbycCL6Gzmsr7jeoLGt~i-GGspDBBqMJLETkBSB4AA~AkYmtyboWJkGoYbS734ufkxbskzYOGwHuAG79CvLt1wiYNviJBQ8EwLd2IIO9-K3");
            IEnumerable<Address> addresses = null;
            //Console.WriteLine("Formatted: " + addresses.First().FormattedAddress); //Formatted: 1600 Pennsylvania Ave SE, Washington, DC 20003, USA
            //Console.WriteLine("Coordinates: " + addresses.First().Coordinates.Latitude + ", " + addresses.First().Coordinates.Longitude); //Coordinates: 38.8791981, -76.9818437

            foreach (var item in list)
            {
                addresses = await geocoder.GeocodeAsync(item.Estate.Address + " " + item.Estate.ZipCode + " "+ item.Estate.City);
                OcMapPoints.Add(new MapPoint()
                {
                    Latitude = addresses.First().Coordinates.Latitude,
                    Longitude = addresses.First().Coordinates.Longitude,
                    Name = item.Title,
                    Description = item.Description

                });
            }

        }
    }
}
