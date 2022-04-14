using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTest
{
    public class Course
    {
        public int Id { get; set; } //Идентифиткатор
        public string Title { get; set; } = string.Empty; //Название курса
        public int Hours { get; set; } //Количество часов
        public Course()
        {

        }
    }
}
