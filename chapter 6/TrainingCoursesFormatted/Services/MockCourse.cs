using TrainingCourses.Models;

namespace SiteCourse.Services
{
    public class MockCourse: ICourse
    {
        private List<Course> _course;
        public MockCourse()
        {
            _course = new List<Course>
            {
                new Course{Id = 1, Title = "Геометрия", Hours = 30 },
                new Course{Id = 2, Title ="История", Hours = 45},
                new Course{Id = 3, Title ="Информатика", Hours = 60}
            };
        }
        public IEnumerable<Course> GetAll()
        {
            return _course;
        }
        public Course Get(int id)
        {
            return _course.FirstOrDefault(x => x.Id.Equals(id)) ?? new Course() { Id = -1 };
        }
        public int Add(Course newCourse)
        {
            newCourse.Id = _course.Max(p => p.Id) + 1;
            _course.Add(newCourse);
            return newCourse.Id;
        }
        public void Save(Course course)
        {
            _course.Where(p => p.Id == course.Id).ToList().ForEach(x => { x.Title = course.Title; x.Hours = course.Hours; });
        }
        public void Delete(Course course)
        {
            _course.Remove(course);
        }
    }
}
