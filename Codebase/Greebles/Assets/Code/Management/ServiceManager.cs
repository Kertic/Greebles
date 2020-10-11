using System;
using System.Collections.Generic;

namespace Code.Management
{
    public class ServiceManager 
    {
        private static readonly ServiceManager _instance = null;
        public static readonly ServiceManager Instance = _instance ?? new ServiceManager();

        private readonly Dictionary<Type, object> _dictionary = new Dictionary<Type, object>();
        public void AddService<T>(T obj)
        {
            if (_dictionary.ContainsKey(typeof(T)))
            {
                throw new Exception("Attempted to add a service who's type is already present. Service type: " + typeof(T));
            }

            _dictionary[typeof(T)] = obj;
        }

        public T Resolve<T>()
        {
            return (T)_dictionary[typeof(T)];
        }
    }
}
