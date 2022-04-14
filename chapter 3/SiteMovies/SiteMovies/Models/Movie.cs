namespace SiteMovies.Models
{
    public class Movie
    {
        //Заголовок
        public string Title { get; set; } = string.Empty;
        //Жанр
        public string Genre { get; set; } = string.Empty;
        //Длительность эпизода
        public int Duration { get; set; }
    }
}
