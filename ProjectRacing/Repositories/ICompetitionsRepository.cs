using ProjectRacing.Entities;
namespace ProjectRacing.Repositories;
public interface ICompetitionsRepository
{
    IEnumerable<TempCompetitionParticipant> GetCompetitionses(DateTime? startDate = null, DateTime? endDate = null, int? horseId = null);
    Competitions GetCompetitionById(int id);
    int CreateCompetitions(Competitions competitions);
    void UpdateCompetitions(Competitions competitions);
    void DeleteCompetitions(int id);
}