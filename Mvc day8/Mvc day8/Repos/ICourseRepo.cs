using Mvc_day8.Models;

namespace Mvc_day8.Repos
{
    public interface ICourseRepo
    {

        List<Course> GetAll();
        Course GetById(int id);
        void Delete(int id);
        void Update(int id, Course course);
        void Add(Course course);
    }
}
