using System.ComponentModel;
namespace ProjectRacing.Entities
{
    /// <summary>
    /// Класс соревнований
    /// </summary>
    public class Competitions
    {
        /// <summary>
        /// Id соревнования
        /// </summary>
        public int Id { get; set; }
        [DisplayName("Дата соревнований")]
        /// <summary>
        /// Дата соревнования
        /// </summary>
        public DateTime DateOfCompetitions { get; set; }
        [DisplayName("Адрес соревнований")]
        /// <summary>
        /// Адрес соревнования
        /// </summary>
        public string Adress { get; set; } = string.Empty;
        [DisplayName("Название соревнований")]
        /// <summary>
        /// Название соревнования
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Конструктор класса соревнований
        /// </summary>
        /// <param name="id">Id соревания</param>
        /// <param name="dateOfCompetitions">Дата соревнования</param>
        /// <param name="adress">Адрес соревнования</param>
        /// <param name="name">Название соревнования</param>
        /// <returns></returns>
        public static Competitions CreateEntity(int id, DateTime dateOfCompetitions, string adress, string name)
        {
            return new Competitions
            {
                Id = id,
                Adress = adress,
                DateOfCompetitions = dateOfCompetitions,
                Name = name
            };
        }
    }
}