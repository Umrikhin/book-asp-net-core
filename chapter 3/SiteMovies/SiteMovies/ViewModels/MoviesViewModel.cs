using SiteMovies.Models;

namespace SiteMovies.ViewModels
{
    public class MoviesViewModel
    {
        public IEnumerable<Comedy> ListComedy { get; set; } = Enumerable.Empty<Comedy>();
        public IEnumerable<Drama> ListDrama { get; set; } = Enumerable.Empty<Drama>();
    }
}
