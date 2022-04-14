using SiteMovies.Models;
using Microsoft.AspNetCore.Mvc;
using SiteMovies.ViewModels;

namespace SiteMovies.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            Movie movie = new Movie()
            {
                Title = "Теория большого взрыва",
                Genre = "Ситком",
                Duration = 20
            };
            return View(movie);
        }

        public IActionResult Movies()
        {
            Movie movie1 = new Movie()
            {
                Title = "Теория большого взрыва",
                Genre = "Ситком",
                Duration = 20
            };
            Movie movie2 = new Movie()
            {
                Title = "Доктор Кто",
                Genre = "Фантастика",
                Duration = 25
            };
            Movie movie3 = new Movie()
            {
                Title = "Игра престолов",
                Genre = "Фэнтези",
                Duration = 63
            };
            List<Movie> collection = new List<Movie>();
            collection.Add(movie1);
            collection.Add(movie2);
            collection.Add(movie3);
            return View(collection);
        }

        public IActionResult GroupMovies()
        {
            Comedy comedy1 = new Comedy()
            {
                Title = "Теория большого взрыва",
                VideoFormat = "1080i (HDTV)"
            };
            Comedy comedy2 = new Comedy()
            {
                Title = "Один дома",
                VideoFormat = "1080i (HDTV)"
            };
            List<Comedy> comedyCollection = new List<Comedy>();
            comedyCollection.Add(comedy1);
            comedyCollection.Add(comedy2);
            Drama drama1  = new Drama()
            {
                Title = "Зеленая миля",
                VideoFormat = "1080i (HDTV)",
                SoundFormat = "Dolby Digital"
            };
            Drama drama2 = new Drama()
            {
                Title = "Джокер",
                VideoFormat = "1080i (HDTV)",
                SoundFormat = "Dolby Digital"
            };
            List<Drama> dramaCollection = new List<Drama>();
            dramaCollection.Add(drama1);
            dramaCollection.Add(drama2);
            MoviesViewModel viewModel = new MoviesViewModel()
            {
                ListComedy = comedyCollection,
                ListDrama = dramaCollection
            };
            return View(viewModel);
        }
    }
}
