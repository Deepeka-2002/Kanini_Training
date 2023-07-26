using MovieAPI.Model;

namespace MovieAPI.Repository
{
    public interface IMoviesInterface
    { 
        public IEnumerable<Movies> GetMovies();
        
        public Movies GetMovieById(int id);
        public IEnumerable<Movies> AddMovies(Movies mov);
    }
}
