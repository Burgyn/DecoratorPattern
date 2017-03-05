using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Services
{
    public class Cache<TValue> : ICache<TValue> where TValue : class
    {
        private object _lock = new object();
        private TValue _cachedValue = null;
        private int _expirationTimeMs = 500;
        private TimeSpan _lastAccess;

        public TValue Get(Func<TValue> factory)
        {
            lock (_lock)
            {
                _lastAccess = DateTime.Now.TimeOfDay;

                if (_cachedValue == null || DateTime.Now.TimeOfDay > (_lastAccess.Add(new TimeSpan(0, 0, 0, 0, _expirationTimeMs))))
                {
                    _cachedValue = factory();
                }

                return _cachedValue;
            }
        }

        public void Reset()
        {
            lock (_lock)
            {
                _cachedValue = null;
            }
        }
    }
}
