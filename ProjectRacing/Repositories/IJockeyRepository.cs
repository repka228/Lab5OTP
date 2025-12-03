using ProjectRacing.Entities;
namespace ProjectRacing.Repositories;
public interface IJockeyRepository
{
    IEnumerable<Jockey> GetJockeys();
    Jockey GetJockeyById(int id);
    void CreateJockey(Jockey jockey);
    void UpdateJockey(Jockey jockey);
    void DeleteJockey(int id);
}