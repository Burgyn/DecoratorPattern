using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DecoratorPattern.Helpers;
using DecoratorPattern.Services;

namespace DecoratorPattern.Model
{
    public class XmlPeopleRepository : IPeopleRepository
    {
        /// <summary>
        /// Gets the people.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetPeople()
        {
            var doc = XDocument.Parse(Properties.Resources.PeopleData);
            return from p in doc.Descendants("Person")
                   select new Person()
                   {
                       Id = int.Parse(p.Attribute("Id").Value),
                       FirstName = p.Attribute("FirstName").Value,
                       LastName = p.Attribute("LastName").Value,
                       Email = p.Attribute("EMail").Value
                   };
        }
    }

}
