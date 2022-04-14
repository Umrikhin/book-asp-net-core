using Microsoft.AspNetCore.Mvc;

namespace FileSending.Controllers
{
    public class HomeController: Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        public HomeController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        //// Отправка по виртуальному пути
        //public VirtualFileResult Index()
        //{
        //    var filepath = Path.Combine("~/Files", "Hello.txt");
        //    return File(filepath, "text/plain", "File.txt");
        //}

        //// Отправка по физическому пути
        //public IActionResult Index()
        //{
        //    string file_path = Path.Combine(_appEnvironment.ContentRootPath, @"Files\HelloFile.txt");
        //    string file_type = "text/plain";
        //    string file_name = "File.txt";
        //    return PhysicalFile(file_path, file_type, file_name);
        //}

        //// Отправка массива байтов
        //public FileResult Index()
        //{
        //    string path = Path.Combine(_appEnvironment.ContentRootPath, @"Files\HelloFile.txt");
        //    byte[] mas = System.IO.File.ReadAllBytes(path);
        //    string file_type = "text/plain";
        //    string file_name = "File.txt";
        //    return File(mas, file_type, file_name);
        //}

        // Отправка потока
        public FileResult Index()
        {
            string path = Path.Combine(_appEnvironment.ContentRootPath, @"Files\HelloFile.txt");
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "text/plain";
            string file_name = "File.txt";
            return File(fs, file_type, file_name);
        }
    }
}
