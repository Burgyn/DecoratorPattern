using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MMLib.RapidPrototyping.Generators;

namespace DecoratorPattern.Model
{
    /// <summary>
    /// This class simulate WebApi people repository. Actualy work with generated data from memory.
    /// </summary>
    public class WebApiPeopleRepository : IPeopleRepository
    {
        public IEnumerable<Person> GetPeople()
        {
            int i = 1;
            return new PersonGenerator().
                Next(1000).
                Select(p => new Person()
                {
                    Id = i++,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Mail,
                });
        }
    }
}
