using ProjectRacing.Entities;
namespace ProjectRacing.Repositories
{
    /// <summary>
    /// Интерфейс репозитория владельца
    /// </summary>
    public interface IOwnerRepository
    {
        /// <summary>
        /// Получения владельцев
        /// </summary>
        /// <returns></returns>
        IEnumerable<Owner> GetOwners();
        /// <summary>
        /// Получения владельца
        /// </summary>
        /// <param name="id">Id владельца</param>
        /// <returns></returns>
        Owner GetOwnerById(int id);
        /// <summary>
        /// Создание владельца
        /// </summary>
        /// <param name="owner">Объект владелец</param>
        void CreateOwner(Owner owner);
        /// <summary>
        /// Обновление владельца
        /// </summary>
        /// <param name="owner">Объект владелец</param>
        void UpdateOwner(Owner owner);
        /// <summary>
        /// Удаление владельца
        /// </summary>
        /// <param name="id">Id владельца</param>
        void DeleteOwner(int id);
    }
}