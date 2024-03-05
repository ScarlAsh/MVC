using Day8Demo_SD44.Models;

namespace Day8Demo_SD44.RepoServices
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();
        public Department GetDetails(int id);
        public void InsertDpt(Department dpt);
        public void UpdateDpt(int id, Department dpt);
        public void DeleteDpt(int id);
    }
}
