using ProjectRacing.Entities;
namespace ProjectRacing.Repositories
{
    public interface IHorseRepository
    {
        IEnumerable<Horse> GetHorses();
        Horse GetHorseById(int id);
        void CreateHorse(Horse horse);
        void UpdateHorse(Horse horse);
        void DeleteHorse(int id);
    }
}