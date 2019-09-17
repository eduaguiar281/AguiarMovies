using AguiarMovies.Models;
using AguiarMovies.Models.Movie;
using System.Threading.Tasks;

namespace AguiarMovies.Services.Movies
{
    public interface IMoviesService
    {
        Task<Movie> FindByIdAsync(int movieId, string language = "pt-BR");

        Task<Movie> GetLatestAsync(string language = "pt-BR");

        Task<SearchResponse<Movie>> GetUpcomingAsync(int pageNumber = 1, string language = "pt-BR");

        Task<SearchResponse<Movie>> GetTopRatedAsync(int pageNumber = 1, string language = "pt-BR");

        Task<SearchResponse<Movie>> GetPopularAsync(int pageNumber = 1, string language = "pt-BR");

        Task<GenreResults> GetGenresAsync(string language = "pt-BR");
    }
}