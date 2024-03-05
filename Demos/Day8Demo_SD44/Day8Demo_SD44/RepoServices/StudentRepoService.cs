using Day8Demo_SD44.Models;
using Microsoft.EntityFrameworkCore;

namespace Day8Demo_SD44.RepoServices
{
    public class StudentRepoService : IStudentRepository
    {
        //StdDbContext context = new StdDbContext ()

        //request service of type StdDbContext to be injected in ctor

        public StdDbContext Context { get; }
        public StudentRepoService(StdDbContext context)
        {
            Context = context;
        }

        public List<Student> GetAll()
        {
            return Context.Students.Include(s=>s.Department).ToList();
        }

        public Student GetDetails(int id)
        {
            return Context.Students.Find(id);
        }

        public void InsertStd(Student std)
        {
            //if(ModelState.IsValid)
            if(std != null) 
            {
                Context.Students.Add(std);
                Context.SaveChanges();
            }
        }

        public void UpdateStd(int id, Student std)
        {
            Student stdUpdated = Context.Students.Find(id);
            if(stdUpdated != null) 
            {
                stdUpdated.StdName = std.StdName;
                stdUpdated.Address = std.Address;
                stdUpdated.Age = std.Age;
                stdUpdated.Email = std.Email;
                stdUpdated.Mark = std.Mark;
                stdUpdated.Password = std.Password;
                stdUpdated.IsActive = std.IsActive;
                stdUpdated.DeptID = std.DeptID;

                Context.SaveChanges();
            }
        }

        public void DeleteStd(int id)
        {
            Student stdDeleted = Context.Students.Find(id);
            if (stdDeleted != null)
            {
                Context.Students.Remove(stdDeleted);
                Context.SaveChanges();
            }
        }
    }
}
