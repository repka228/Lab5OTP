using System.ComponentModel;
namespace ProjectRacing.Entities
{
    /// <summary>
    /// Класс жокея
    /// </summary>
    public class Jockey
    {
        /// <summary>
        /// ID жокея
        /// </summary>
        public int Id { get; private set; }
        [DisplayName("Имя жокея")]
        /// <summary>
        /// Имя жокея
        /// </summary>
        public string NameOfJockey { get; private set; } = string.Empty;
        [DisplayName("Возраст жокея")]
        /// <summary>
        /// Возраст жокея
        /// </summary>
        public int Age { get; private set; }
        [DisplayName("Рейтинг жокея")]
        /// <summary>
        /// Рейтинг жокея
        /// </summary>
        public int Rating { get; private set; }
        [DisplayName("Номер жокея")]
        /// <summary>
        /// Номер жокея
        /// </summary>
        public string Number { get; private set; } = string.Empty;
        /// <summary>
        /// Создание жокея
        /// </summary>
        /// <param name="id">Id жокея</param>
        /// <param name="nameOfJockey">Имя жокея</param>
        /// <param name="age">Возраст жокея</param>
        /// <param name="rating">Рейтинг жокея</param>
        /// <param name="number">Номер жокея</param>
        /// <returns></returns>
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