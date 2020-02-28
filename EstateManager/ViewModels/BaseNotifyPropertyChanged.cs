using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.ViewModels
{
    public abstract class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        private Dictionary<string, object> _propertyValues = new Dictionary<string, object>();
        public T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            return GetProperty<T>(propertyName, out bool exists);
        }
        private T GetProperty<T>(string propertyName, out bool exists)
        {
            exists = false;
            if (_propertyValues.ContainsKey(propertyName))
            {
                exists = true;
                return (T)_propertyValues[propertyName];
            }
            return default(T);
        }
        public bool SetProperty<T>(T value, [CallerMemberName] string propertyName = null)
        {
            var current = GetProperty<T>(propertyName, out bool exists);
            if (!EqualityComparer<T>.Default.Equals(current, value))
            {
                if (exists)
                    _propertyValues[propertyName] = value;
                else
                    _propertyValues.Add(propertyName, value);
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
