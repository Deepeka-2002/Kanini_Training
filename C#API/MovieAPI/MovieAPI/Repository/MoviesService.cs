using Microsoft.AspNetCore.Authorization;
using MovieAPI.Model;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace MovieAPI.Repository
{
    public class MoviesService : IMoviesInterface
    {
       private readonly MovieContext movieContext;

        public MoviesService(MovieContext context)
        {
            movieContext = context;
        }

        public IEnumerable<Movies> GetMovies()
        {
            return movieContext.movies.ToList();
        }

        public Movies GetMovieById(int id)
        {
            return movieContext.movies.FirstOrDefault(x => x.MovieId == id);
        }

        public IEnumerable<Movies>  AddMovies(Movies mov)
        {
            movieContext.movies.Add(mov);
            movieContext.SaveChanges();
            return movieContext.movies.ToList();
        }
    }
}
