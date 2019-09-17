using Autofac;
using AguiarMovies.Services.Movies;
using AguiarMovies.Services.Navigation;
using AguiarMovies.Services.Request;
using System;

namespace AguiarMovies.ViewModels.Base
{
    public class Locator
    {
        private static IContainer _container;

        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected Locator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<RequestService>().As<IRequestService>();
            builder.RegisterType<MoviesService>().As<IMoviesService>();

            builder.RegisterType<DetailViewModel>();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<SplashViewModel>();
            builder.RegisterType<UpcomingViewModel>();

            if (_container != null)
            {
                _container.Dispose();
            }

            _container = builder.Build();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}