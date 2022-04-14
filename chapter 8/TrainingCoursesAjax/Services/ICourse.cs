using TrainingCourses.Models;

namespace SiteCourse.Services
{
    public interface ICourse
    {
        IEnumerable<Course> GetAll();
        public Course Get(int id);
        int Add(Course newCourse);
        void Save(Course course);
        void Delete(Course course);
    }
}
