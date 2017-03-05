using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPattern.Model;

namespace DecoratorPattern.ViewModel
{
    public class PeopleViewModel
    {
        private IPeopleRepository _peopleRepository;
        private Lazy<ObservableCollection<Person>> _itemsSource;

        public PeopleViewModel(IPeopleRepository peopleRepository)
        {
            if (peopleRepository == null)
            {
                throw new ArgumentNullException(nameof(peopleRepository));
            }

            _peopleRepository = peopleRepository;
            _itemsSource = new Lazy<ObservableCollection<Model.Person>>(() => new ObservableCollection<Person>(_peopleRepository.GetPeople()));
        }

        public ObservableCollection<Person> ItemsSource
        {
            get
            {
                return _itemsSource.Value;
            }
        }
    }
}
