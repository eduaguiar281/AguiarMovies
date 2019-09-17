using AguiarMovies.Services.Navigation;
using AguiarMovies.ViewModels.Base;
using System.Threading.Tasks;

namespace AguiarMovies.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private MenuViewModel _menuViewModel;
        private UpcomingViewModel _homeViewModel;

        private INavigationService _navigationService;

        public MainViewModel(
            INavigationService navigationService, 
            MenuViewModel menuViewModel,
            UpcomingViewModel homeViewModel)
        {
            _navigationService = navigationService;
            _menuViewModel = menuViewModel;
            _homeViewModel = homeViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get
            {
                return _menuViewModel;
            }

            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public UpcomingViewModel HomeViewModel
        {
            get
            {
                return _homeViewModel;
            }

            set
            {
                _homeViewModel = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAll
                (
                    _menuViewModel.InitializeAsync(navigationData),
                    _navigationService.NavigateToAsync<UpcomingViewModel>()
                );
        }
    }
}