using System.ComponentModel.DataAnnotations;

namespace TrainingCourses.Models
{
    public class Course
    {
        public int Id { get; set; } //Идентификатор
        [Required(ErrorMessage = "Укажите наименование курса")]
        public string Title { get; set; } = string.Empty; //Название курса
        [Range(1, 300, ErrorMessage = "Количество часов должно быть в промежутке от 1 до 300")]
        [Required(ErrorMessage = "Укажите количество часов")]
        public int Hours { get; set;} //Количество часов
        public Course()
        {

        }
    }
}
