﻿using AguiarMovies.Models;
using AguiarMovies.Models.Movie;
using AguiarMovies.Services.Request;
using System.Threading.Tasks;

namespace AguiarMovies.Services.Movies
{
    public class MoviesService : IMoviesService
    {
        private readonly IRequestService _requestProvider;

        public MoviesService(IRequestService requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<Movie> FindByIdAsync(int movieId, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}movie/{movieId}?api_key={AppSettings.ApiKey}&language={language}";

            Movie response = await _requestProvider.GetAsync<Movie>(uri);

            return response;
        }

        public async Task<Movie> GetLatestAsync(string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}movie/latest?api_key={AppSettings.ApiKey}&language={language}";

            Movie response = await _requestProvider.GetAsync<Movie>(uri);

            return response;
        }

        public async Task<SearchResponse<Movie>> GetPopularAsync(int pageNumber = 1, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}movie/popular?api_key={AppSettings.ApiKey}&language={language}&page={pageNumber}";

            SearchResponse<Movie> response = await _requestProvider.GetAsync<SearchResponse<Movie>>(uri);

            return response;
        }

        public async Task<SearchResponse<Movie>> GetTopRatedAsync(int pageNumber = 1, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}movie/top_rated?api_key={AppSettings.ApiKey}&language={language}&page={pageNumber}";

            SearchResponse<Movie> response = await _requestProvider.GetAsync<SearchResponse<Movie>>(uri);

            return response;
        }

        public async Task<SearchResponse<Movie>> GetUpcomingAsync(int pageNumber = 1, string language = "en")
        {
            string uri = $"{AppSettings.ApiUrl}movie/upcoming?api_key={AppSettings.ApiKey}&language={language}&page={pageNumber}";

            SearchResponse<Movie> response = await _requestProvider.GetAsync<SearchResponse<Movie>>(uri);

            return response;
        }

        public async Task<GenreResults> GetGenresAsync(string language = "pt-BR")
        {
            string uri = $"{AppSettings.ApiUrl}genre/movie/list?api_key={AppSettings.ApiKey}&language={language}";
            GenreResults response = await _requestProvider.GetAsync<GenreResults>(uri);
            return response;
        }

    }
}