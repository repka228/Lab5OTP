using ProjectRacing.Entities.Enums;
using System.ComponentModel;
namespace ProjectRacing.Entities
{
    public class Horse
    {
        public int Id { get; private set; }
        [DisplayName("Кличка")]
        public string NameOfHorse { get; private set; } = string.Empty;
        [DisplayName("Пол")]
        public Gender Sex { get; private set; }
        [DisplayName("Дата рождения")]
        public DateTime Birthday { get; private set; }
        [Browsable(false)]
        public int OwnerId { get; private set; }
        [DisplayName("Имя владельца")]
        public string OwnerName { get; private set; } = string.Empty;
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