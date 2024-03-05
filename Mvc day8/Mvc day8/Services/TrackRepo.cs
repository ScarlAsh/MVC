using Mvc_day8.Data;
using Mvc_day8.Models;
using Mvc_day8.Repos;

namespace Mvc_day8.Services
{
    public class TrackRepo : ITrackRepo
    {
        public TrackRepo(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public void Add(Track track)
        {
            if(track !=null)
            {
                Context.Tracks.Add(track);
                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var track = Context.Tracks.Find(id);
            if (track != null)
            {
                Context.Tracks.Remove(track);
                Context.SaveChanges();
            }
        }

        public List<Track> GetAll()
        {
            return Context.Tracks.ToList();
        }

        public Track GetById(int id)
        {
           return Context.Tracks.Find(id);
        }

        public void Update(int id, Track track)
        {
            var oldtrack =Context.Tracks.Find(id);
            if(oldtrack != null)
            {
                oldtrack.Description = track.Description;
                oldtrack.Name = track.Name;
                Context.SaveChanges();
            }
        }
    }
}
