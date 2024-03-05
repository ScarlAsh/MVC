using Day8Demo_SD44.Models;

namespace Day8Demo_SD44.RepoServices
{
    public interface IStudentRepository
    {
        public List<Student> GetAll();
        public Student GetDetails(int id);
        public void InsertStd(Student std);
        public void UpdateStd(int id, Student std);
        public void DeleteStd(int id);
    }
}
