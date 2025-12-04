using ProjectRacing.Entities.Enums;
using System.ComponentModel;
namespace ProjectRacing.Entities
{
    /// <summary>
    /// Класс лошади
    /// </summary>
    public class Horse
    {
        /// <summary>
        /// ID лошади
        /// </summary>
        public int Id { get; private set; }
        [DisplayName("Кличка")]
        /// <summary>
        /// Кличка лошади
        /// </summary>
        public string NameOfHorse { get; private set; } = string.Empty;
        [DisplayName("Пол")]
        /// <summary>
        /// Пол лошади
        /// </summary>
        public Gender Sex { get; private set; }
        [DisplayName("Дата рождения")]
        /// <summary>
        /// День рождения лошади
        /// </summary>
        public DateTime Birthday { get; private set; }
        [Browsable(false)]
        /// <summary>
        /// ID владелцьа
        /// </summary>
        public int OwnerId { get; private set; }
        /// <summary>
        /// Создание лошади
        /// </summary>
        /// <param name="id">Id лошади</param>
        /// <param name="nameOfHorse">Кличка лошади</param>
        /// <param name="sex">Пол лошади</param>
        /// <param name="birthday">День рождения лошади</param>
        /// <param name="ownerId">Id владельца</param>
        /// <returns></returns>
        public static Horse CreateEntity(int id, string nameOfHorse, Gender sex, DateTime birthday, int ownerId)
        {
            return new Horse
            {
                Id = id,
                NameOfHorse = nameOfHorse,
                Sex = sex,
                Birthday = birthday,
                OwnerId = ownerId
            };
        }
    }
}