using System.ComponentModel;
namespace ProjectRacing.Entities
{
    public class Jockey
    {
        public int Id { get; private set; }
        [DisplayName("Имя жокея")]
        public string NameOfJockey { get; private set; } = string.Empty;
        [DisplayName("Возраст жокея")]
        public int Age { get; private set; }
        [DisplayName("Рейтинг жокея")]
        public int Rating { get; private set; }
        [DisplayName("Номер жокея")]
        public string Number { get; private set; } = string.Empty;
        public static Jockey CreateEntity(int id, string nameOfJockey, int age, int rating, string number)
        {
            return new Jockey
            {
                Id = id,
                NameOfJockey = nameOfJockey,
                Age = age,
                Rating = rating,
                Number = number
            };
        }
    }
}