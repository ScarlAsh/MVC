using Day8Demo_SD44.Models;

namespace Day8Demo_SD44.RepoServices
{
    public class DepartmentRepoService : IDepartmentRepository
    {
        public StdDbContext Context { get; }
        public DepartmentRepoService(StdDbContext context)
        {
            Context = context;
        }

        public List<Department> GetAll()
        {
            return Context.Departments.ToList();
        }

        public Department GetDetails(int id)
        {
            return Context.Departments.Find(id);
        }

        public void InsertDpt(Department dpt)
        {
            throw new NotImplementedException();
        }

        public void UpdateDpt(int id, Department dpt)
        {
            throw new NotImplementedException();
        }
        public void DeleteDpt(int id)
        {
            throw new NotImplementedException();
        }
    }
}
