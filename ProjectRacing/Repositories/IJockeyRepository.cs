using ProjectRacing.Entities;
namespace ProjectRacing.Repositories
{
    /// <summary>
    /// Интерфейс репозитория жокея
    /// </summary>
    public interface IJockeyRepository
    {
        /// <summary>
        /// Получения жокеев
        /// </summary>
        /// <returns></returns>
        IEnumerable<Jockey> GetJockeys();
        /// <summary>
        /// Получения жокея
        /// </summary>
        /// <param name="id">Id жокея</param>
        /// <returns></returns>
        Jockey GetJockeyById(int id);
        /// <summary>
        /// Создание жокея
        /// </summary>
        /// <param name="jockey">Объект жокея</param>
        void CreateJockey(Jockey jockey);
        /// <summary>
        /// Обновление жокея
        /// </summary>
        /// <param name="jockey">Объект жокея</param>
        void UpdateJockey(Jockey jockey);
        /// <summary>
        /// Удаление жокея
        /// </summary>
        /// <param name="id">Id жокея</param>
        void DeleteJockey(int id);
    }
}