using Microsoft.EntityFrameworkCore;
using Mvc_day8.Data;
using Mvc_day8.Models;
using Mvc_day8.Repos;

namespace Mvc_day8.Services
{
    public class TraineeRepo : ITraineeRepo
    {
        private readonly ApplicationDbContext Context;
        public TraineeRepo(ApplicationDbContext _context)
        {
            Context = _context;
        }

        public void Add(Trainee trainee)
        {
           if(trainee !=null)
           {
                Context.Trainees.Add(trainee);
                Context.SaveChanges();
           }
        }

        public void Delete(int id)
        {
            var trainee = Context.Trainees.Find(id);
            if (trainee != null)
            {
                Context.Trainees.Remove(trainee);
                Context.SaveChanges();
            }
        }

        public List<Trainee> GetAll()
        {
            return Context.Trainees.Include(i => i.Course).Include(i => i.Track).ToList();
        }

        public Trainee GetById(int id)
        {
            return Context.Trainees.Find(id);
        }

        public void Update(int id , Trainee trainee)
        {
            var oldtrainee = Context.Trainees.Find(id);
            if(oldtrainee != null)
            {
                oldtrainee.Name = trainee.Name;
                oldtrainee.Email = trainee.Email;
                oldtrainee.Gender = trainee.Gender;
                oldtrainee.BirthDate = trainee.BirthDate;
                oldtrainee.MobileNo = trainee.MobileNo;
                oldtrainee.CourseId = trainee.CourseId;
                oldtrainee.TrackId = trainee.TrackId;

                Context.SaveChanges();

            }
        }
    }
}
