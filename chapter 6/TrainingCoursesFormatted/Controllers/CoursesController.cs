using Microsoft.AspNetCore.Mvc;
using SiteCourse.Services;
using TrainingCourses.Models;

namespace TrainingCourses.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly ICourse _course;
        public CoursesController(ICourse course)
        {
            _course = course;
        }
        // GET api/courses
        [HttpGet]
        //[Produces("application/xml")]
        [FormatFilter]
        public IEnumerable<Course> Get()
        {
            return _course.GetAll();
        }
        // GET api/courses/3
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = _course.Get(id);
            if (course == null || course.Id == -1)
                return NotFound();
            return new ObjectResult(course);
        }
        // POST api/courses
        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            // обработка частных случаев валидации
            if (course.Hours == 3)
                ModelState.AddModelError("Hours", "Количество часов не должно быть равно 3");
            if (course.Title.ToLower().IndexOf("нумерология") > -1)
            {
                ModelState.AddModelError("Title", "Недопустимое наименование курса - Нумерология");
            }
            // если есть ошибки - возвращаем ошибку 400
            if (!ModelState.IsValid)
            {
                string validationErrors = string.Join(". ",
                    ModelState.Values.Where(E => E.Errors.Count > 0)
                    .SelectMany(E => E.Errors)
                    .Select(E => E.ErrorMessage)
                    .ToArray());
                return BadRequest(validationErrors);
            }
            // если ошибок нет, сохраняем элемент
            int newId = 0;
            try
            {
                newId = _course.Add(course);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return Ok(newId);
        }
        // PUT api/courses/3
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Course model)
        {
            var course = _course.Get(id);
            course.Title = model.Title; course.Hours = model.Hours;
            _course.Save(course);
        }
        // DELETE api/courses/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var course = _course.Get(id);
            _course.Delete(course);
        }
    }
}
