using ProjectRacing.Entities;
namespace ProjectRacing.Repositories
{
    /// <summary>
    /// Интерфейс репозитория участников
    /// </summary>
    public interface IParticipantsRepository
    {
        /// <summary>
        /// Получение участников-соревнований
        /// </summary>
        /// <param name="competitionIds">Id соревнований</param>
        /// <param name="horseId">Id участников</param>
        /// <param name="startDate">Начало периода</param>
        /// <param name="endDate">Конец периода</param>
        /// <returns></returns>
        IEnumerable<TempCompetitionParticipant> GetParticipants(IEnumerable<int>? competitionIds = null, int? horseId = null, DateTime? startDate = null, DateTime? endDate = null);
        /// <summary>
        /// Получение участников
        /// </summary>
        /// <param name="id">Id участников</param>
        /// <returns></returns>
        Participants GetParticipantsByCompetitionId(int id);
        /// <summary>
        /// Создание участников соревнований
        /// </summary>
        /// <param name="participants">Сущность участников</param>
        void CreateParticipants(Participants participants);
        /// <summary>
        /// Обновление участников-соревнований
        /// </summary>
        /// <param name="participants"></param>
        void UpdateParticipants(Participants participants);
        /// <summary>
        /// Удаление участников-соревнований
        /// </summary>
        /// <param name="id"></param>
        void DeleteParticipants(int id);
    }
}