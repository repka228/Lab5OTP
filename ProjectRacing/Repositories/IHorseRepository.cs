using ProjectRacing.Entities;
namespace ProjectRacing.Repositories
{
    /// <summary>
    /// Интерфейс репозитория лошадей
    /// </summary>
    public interface IHorseRepository
    {
        /// <summary>
        /// Получения лошадей
        /// </summary>
        /// <returns></returns>
        IEnumerable<Horse> GetHorses();
        /// <summary>
        /// Получения жокея по Id
        /// </summary>
        /// <param name="id">Id лошади</param>
        /// <returns></returns>
        Horse GetHorseById(int id);
        /// <summary>
        /// Создание лошади
        /// </summary>
        /// <param name="horse">Объект лошадь</param>
        void CreateHorse(Horse horse);
        /// <summary>
        /// Обновление лошади
        /// </summary>
        /// <param name="horse">Объект лошадь</param>
        void UpdateHorse(Horse horse);
        /// <summary>
        /// Удаление лошади
        /// </summary>
        /// <param name="id">Id лошади</param>
        void DeleteHorse(int id);
    }
}