using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPattern.Helpers;
using DecoratorPattern.Services;

namespace DecoratorPattern.Model
{
    public class LogPeopleRepository : IPeopleRepository
    {
        private ILogger _logger;
        private IPeopleRepository _peopleRepository;

        public LogPeopleRepository(ILogger logger, IPeopleRepository peopleRepository)
        {
            Check.NotNull(logger, nameof(logger));
            Check.NotNull(peopleRepository, nameof(peopleRepository));

            _logger = logger;
            _peopleRepository = peopleRepository;
        }

        public IEnumerable<Person> GetPeople()
        {
            IEnumerable<Person> ret = null;

            Measure(() =>
            {
                ret = _peopleRepository.GetPeople();
            }, nameof(GetPeople));

            return ret;
        }

        private void Measure(Action action, string message)
        {
            var sw = new Stopwatch();
            sw.Start();

            action();

            sw.Stop();

            _logger.Log($"Operation '{message}' take: {sw.ElapsedMilliseconds} ms.");
        }
    }
}
