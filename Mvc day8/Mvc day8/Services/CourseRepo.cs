using Mvc_day8.Data;
using Mvc_day8.Models;
using Mvc_day8.Repos;

namespace Mvc_day8.Services
{
    public class CourseRepo : ICourseRepo
    {
        public CourseRepo(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public void Add(Course course)
        {
            if(course != null)
            {
                Context.Courses.Add(course);
                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var course = Context.Courses.Find(id);
            if(course != null)
            {
                Context.Courses.Remove(course);
                Context.SaveChanges();
            }
        }

        public List<Course> GetAll()
        {
            return Context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return Context.Courses.Find(id);
        }

        public void Update(int id, Course course)
        {
            var oldcourse = Context.Courses.Find(id); 
            if(oldcourse != null)
            {
                oldcourse.Topic = course.Topic;
                oldcourse.Grade = course.Grade;

                Context.SaveChanges();
            }
        }
    }
}
