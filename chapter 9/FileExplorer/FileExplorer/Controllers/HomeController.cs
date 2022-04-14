using FileExplorer.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment Environment;
        public HomeController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View(GetFiles());
        }
        List<FileModel> GetFiles()
        {
            //Получаем все файлы в папке
            string[] filePaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "Files/"));
            //Копируем имена файлов в коллекцию моделей
            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return files;
        }
        public FileResult DownloadFile(string fileName)
        {
            //Получаем путь к файлу.
            string path = Path.Combine(this.Environment.WebRootPath, "Files/") + fileName;
            //Чтение данных файла в массив байтов.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //Отправить файл для загрузки
            return File(bytes, "application/octet-stream", fileName);
        }
        [HttpPost]
        [RequestSizeLimit(1048576)]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pathDir = Path.Combine(this.Environment.WebRootPath, "Files/");
                    var fileName = System.IO.Path.GetFileName(uploadedFile.FileName);
                    FileInfo f = new System.IO.FileInfo(fileName);
                    using (var fileStream = new FileStream(Path.Combine(pathDir, f.Name), FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View("Index", GetFiles());
                }
            }
            else
            {
                ModelState.AddModelError("", "Модель недействительна");
                return View("Index", GetFiles());
            }
        }
    }
}
