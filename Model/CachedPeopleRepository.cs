using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPattern.Helpers;
using DecoratorPattern.Services;

namespace DecoratorPattern.Model
{
    public class CachedPeopleRepository : IPeopleRepository
    {
        private IPeopleRepository _peopleRepository;
        private ICache<IEnumerable<Person>> _cache;

        public CachedPeopleRepository(ICache<IEnumerable<Person>> cache, IPeopleRepository peopleRepository)
        {
            Check.NotNull(cache, nameof(cache ));
            Check.NotNull(peopleRepository, nameof(peopleRepository));

            _cache = cache;
            _peopleRepository = peopleRepository;
        }

        public IEnumerable<Person> GetPeople()
        {
            return _cache.Get(() => _peopleRepository.GetPeople());
        }
    }
}
