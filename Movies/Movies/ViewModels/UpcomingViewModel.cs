using System.Threading.Tasks;
using AguiarMovies.ViewModels.Base;
using AguiarMovies.Services.Movies;
using System.Collections.ObjectModel;
using AguiarMovies.Models.Movie;
using System.Linq;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using AguiarMovies.Services.Navigation;
using Xamarin.Forms.Extended;
using System.Collections.Generic;
using AguiarMovies.Services.Request;

namespace AguiarMovies.ViewModels
{
    public class UpcomingViewModel : ViewModelBase
    {
        protected InfiniteScrollCollection<Movie> _upcoming;

        protected IMoviesService _moviesService;
        protected INavigationService _navigationService;

        public UpcomingViewModel(
            IMoviesService moviesService,
            INavigationService navigationService)
        {
            _moviesService = moviesService;
            _navigationService = navigationService;
        }

        public InfiniteScrollCollection<Movie> Upcoming
        {
            get { return _upcoming; }
            set
            {
                _upcoming = value;
                OnPropertyChanged();
            }
        }

        public ICommand MovieDetailCommand => new Command<Movie>(MovieDetailAsync);

        protected int _totalPages = 1;
        protected int _currentPage = 0;

        protected bool _hasMorePages;

        private bool _isLoadMorebusy = false;
        public bool IsLoadMorebusy
        {
            get { return _isLoadMorebusy; }
            set
            {
                _isLoadMorebusy = value;
                OnPropertyChanged();
            }
        }

        private bool _isEmpty = false;
        public bool IsEmpty
        {
            get { return _isEmpty; }
            set
            {
                _isEmpty = value;
                OnPropertyChanged();
            }
        }


        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            try
            {
                var list = await GetMoreUpComingAsync();
                Upcoming = new InfiniteScrollCollection<Movie>(list);
                Upcoming.OnLoadMore += GetMoreUpComingAsync;
                Upcoming.OnCanLoadMore = () => _hasMorePages;
                IsEmpty = list.Count() == 0;
                
            }
            catch (RestRequestException ex)
            {
                IsEmpty = true;
                MessagingCenter.Send(this, AppSettings.DialogMessage, ex.Message);
            }
            catch (Exception ex)
            {
                IsEmpty = true;
                MessagingCenter.Send(this, AppSettings.DialogMessage, "Ocorreu um erro inesperado ao obter lista de Filmes");
            }
            finally
            {
                IsBusy = false;
            }

        }

        protected virtual async Task<IEnumerable<Movie>> GetMoreUpComingAsync()
        {
            IsLoadMorebusy = !IsBusy ? true : false;
            try
            {
                _currentPage++;
                var upcoming = await _moviesService.GetUpcomingAsync(_currentPage, "pt-BR");
                var results = upcoming.Results.ToList().OrderBy(m => m.ReleaseDate);
                _totalPages = upcoming.TotalPages;
                _hasMorePages = _currentPage < _totalPages;

                return results;
            }
            catch (RestRequestException ex)
            {
                _hasMorePages = false;
                throw ex;
            }
            catch (Exception ex)
            {
                _hasMorePages = false;
                throw ex;
            }
            finally
            {
                IsLoadMorebusy = false;
            }
        }

        private async void MovieDetailAsync(object obj)
        {
            var movie = obj as Movie;

            if (movie != null)
            {
                await _navigationService.NavigateToAsync<DetailViewModel>(movie);
            }
        }
    }
}