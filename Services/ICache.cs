using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Services
{
    public interface ICache<TValue>
    {
        TValue Get(Func<TValue> factory);

        void Reset();
    }
}
