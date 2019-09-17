using System.Threading.Tasks;
using AguiarMovies.ViewModels.Base;
using AguiarMovies.Services.Navigation;

namespace AguiarMovies.ViewModels
{
    public class SplashViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public SplashViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await _navigationService.NavigateToAsync<MainViewModel>();
        }
    }
}