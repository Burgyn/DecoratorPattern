using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Model
{
    public interface IPeopleRepository
    {
        /// <summary>
        /// Gets the people.
        /// </summary>
        IEnumerable<Person> GetPeople();
    }
}
