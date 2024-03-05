using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Mvc_day8.Models;

namespace Mvc_day8.Repos
{
    public interface ITraineeRepo
    {
            List<Trainee> GetAll();
            Trainee GetById(int id);
            void Delete(int id);
            void Update(int id , Trainee trainee);  
            void Add(Trainee trainee);        
    }
}
