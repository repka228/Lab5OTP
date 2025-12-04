using ProjectRacing.Entities;
namespace ProjectRacing.Repositories
{
    public interface IParticipantsRepository
    {
        IEnumerable<TempCompetitionParticipant> GetParticipants(IEnumerable<int>? competitionIds = null, int? horseId = null, DateTime? startDate = null, DateTime? endDate = null);
        Participants GetParticipantsByCompetitionId(int id);
        void CreateParticipants(Participants participants);
        void UpdateParticipants(Participants participants);
        void DeleteParticipants(int id);
    }
}