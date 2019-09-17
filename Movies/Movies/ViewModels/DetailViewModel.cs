using AguiarMovies.ViewModels.Base;
using System.Threading.Tasks;
using AguiarMovies.Models.Movie;
using AguiarMovies.Services.Movies;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using AguiarMovies.Services.Navigation;
using System;
using System.Collections.Generic;
using AguiarMovies.Services.Request;

namespace AguiarMovies.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        private Movie _movie;
        private string _video;

        private INavigationService _navigationService;
        private IMoviesService _moviesService;

        public DetailViewModel(
            INavigationService navigationService,
            IMoviesService moviesService)
        {
            _navigationService = navigationService;
            _moviesService = moviesService;
        }

        private void GetGenres(IReadOnlyCollection<Models.Genre.Genre> genres)
        {
            TextGenres = "";
            if (genres == null)
                return;
            if (genres.Count == 0)
                return;
            foreach (var genre in genres)
            {
                TextGenres += genre.Name + ", ";
            }
            TextGenres = TextGenres.Substring(0, TextGenres.Length - 2);
        }


        public string _textGenres;
        public string TextGenres
        {
            get { return _textGenres; }
            set
            {
                _textGenres = value;
                OnPropertyChanged();
            }
        }

        public Movie Movie
        {
            get { return _movie; }
            set
            {
                _movie = value;
                OnPropertyChanged();
            }
        }

        public string Video
        {
            get { return _video; }
            set
            {
                _video = value;
                OnPropertyChanged();
            }
        }


        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Movie)
            {
                IsBusy = true;

                var movie = (Movie)navigationData;
                try
                {
                    Movie = await _moviesService.FindByIdAsync(movie.Id);
                    GetGenres(Movie.Genres);
                }
                catch (RestRequestException ex)
                {
                    MessagingCenter.Send(this, AppSettings.DialogMessage, ex.Message);
                }
                catch (Exception ex)
                {
                    MessagingCenter.Send(this, AppSettings.DialogMessage, "Ocorreu um erro inesperado ao exibir informações do Filme");
                }

                IsBusy = false;
            }
        }

        private void Play()
        {
            if (string.IsNullOrEmpty(Video))
                return;

            Device.OpenUri(new Uri(Video));
        }

    }
}