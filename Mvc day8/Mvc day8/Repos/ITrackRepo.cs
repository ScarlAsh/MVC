using Mvc_day8.Models;

namespace Mvc_day8.Repos
{
    public interface ITrackRepo
    {

        List<Track> GetAll();
        Track GetById(int id);
        void Delete(int id);
        void Update(int id, Track track);
        void Add(Track track);
    }
}
