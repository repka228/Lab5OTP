using ProjectRacing.Entities;
namespace ProjectRacing.Repositories
{
    /// <summary>
    /// Интерфейс репозитория соревнований
    /// </summary>
    public interface ICompetitionsRepository
    {
        /// <summary>
        /// Получения соревнований
        /// </summary>
        /// <param name="startDate">Начало периода</param>
        /// <param name="endDate">Конец периода</param>
        /// <param name="horseId">Id лошади</param>
        /// <returns></returns>
        IEnumerable<TempCompetitionParticipant> GetCompetitionses(DateTime? startDate = null, DateTime? endDate = null, int? horseId = null);
        /// <summary>
        /// Получение соревнований по Id
        /// </summary>
        /// <param name="id">Id соревнований</param>
        /// <returns></returns>
        Competitions GetCompetitionById(int id);
        /// <summary>
        /// Создание соревнований
        /// </summary>
        /// <param name="competitions">Объект соревнования</param>
        /// <returns></returns>
        int CreateCompetitions(Competitions competitions);
        /// <summary>
        /// Обновление соревнований
        /// </summary>
        /// <param name="competitions">Объект соревнования</param>
        void UpdateCompetitions(Competitions competitions);
        /// <summary>
        /// Удаление соревнования
        /// </summary>
        /// <param name="id">Id соревнования</param>
        void DeleteCompetitions(int id);
    }
}