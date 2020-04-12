using EstateManager.Models;
using Geocoding;
using Geocoding.Microsoft;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EstateManager.ViewModels
{
    class MapViewModel : BaseNotifyPropertyChanged
    {
        public ObservableCollection<MapPoint> OcMapPoints
        {
            get { return GetProperty<ObservableCollection<MapPoint>>(); }
            set { SetProperty<ObservableCollection<MapPoint>>(value); }
        }

        public MapViewModel()
        {
            var dbContext = DataAccess.EstateManagerContext.Current;
            OcMapPoints = new ObservableCollection<MapPoint>();
            var locationTransacList = dbContext.Transactions.Include(b => b.Estate).ToList();
            var locationAppList = dbContext.Appointments.ToList();
            var locationClientsList = dbContext.Persons.ToList();
            Task t = Task.Run(() => PlacePointsAsync(locationTransacList, locationAppList, locationClientsList));
        }

        async Task PlacePointsAsync(List<Transaction> listTransac, List<Appointment> listAppoint, List<Person> listClients)
        {

            IGeocoder geocoder = new BingMapsGeocoder("2nbycCL6Gzmsr7jeoLGt~i-GGspDBBqMJLETkBSB4AA~AkYmtyboWJkGoYbS734ufkxbskzYOGwHuAG79CvLt1wiYNviJBQ8EwLd2IIO9-K3");
            IEnumerable<Address> addresses = null;

            foreach (var item in listTransac)
            {
                try
                {
                    addresses = await geocoder.GeocodeAsync(item.Estate.Address + " " + item.Estate.ZipCode + " " + item.Estate.City);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        OcMapPoints.Add(new MapPoint()
                        {
                            Latitude = addresses.First().Coordinates.Latitude,
                            Longitude = addresses.First().Coordinates.Longitude,
                            Name = item.Title,
                            Description = item.Description

                        });
                    });
                }
                catch (Exception)
                {
                }

            }
            foreach (var item in listAppoint)
            {
                try
                {
                    addresses = await geocoder.GeocodeAsync(item.Address + " " + item.ZipCode + " " + item.City);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                            OcMapPoints.Add(new MapPoint()
                        {
                            Latitude = addresses.First().Coordinates.Latitude,
                            Longitude = addresses.First().Coordinates.Longitude,
                            Name = item.Reason,
                            Description = item.Person1.FirstName + " avec " + item.Person2.FirstName

                        });
                    });
                }
                catch (Exception)
                {
                }

            }
            foreach (var item in listClients)
            {
                try
                {
                    addresses = await geocoder.GeocodeAsync(item.Address + " " + item.ZipCode + " " + item.City);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        OcMapPoints.Add(new MapPoint()
                        {
                            Latitude = addresses.First().Coordinates.Latitude,
                            Longitude = addresses.First().Coordinates.Longitude,
                            Name = item.FirstName + " " + item.LastName,
                            Description = item.Mail
                        });
                    });
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
