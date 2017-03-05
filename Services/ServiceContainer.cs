using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPattern.Model;
using DecoratorPattern.ViewModel;

namespace DecoratorPattern.Services
{
    public class ServiceContainer
    {
        private LightInject.ServiceContainer _container = new LightInject.ServiceContainer();

        private ServiceContainer()
        {
            Register();
        }
        private void Register()
        {
            _container.Register<IPeopleRepository, XmlPeopleRepository>();
            _container.Decorate<IPeopleRepository, CachedPeopleRepository>();
            _container.Decorate<IPeopleRepository, LogPeopleRepository>();

            _container.Register(typeof(ICache<>), typeof(Cache<>));
            _container.Register<ILogger, ConsoleLogger>();
            _container.Register<PeopleViewModel>();
            _container.Register<MainWindow>();
        }

        public static ServiceContainer Instance { get; } = new ServiceContainer();

        public T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }
    }
}
