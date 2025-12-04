using System.ComponentModel;
namespace ProjectRacing.Entities
{
    /// <summary>
    /// Класс временные участники-соревнования
    /// </summary>
    public class TempCompetitionParticipant
    {
        /// <summary>
        /// Id лошади
        /// </summary>
        public int HorseId { get; private set; }
        /// <summary>
        /// Id соревнования
        /// </summary>
        public int IdCompetitions { get; private set; }
        [DisplayName("Название соревнования")]
        /// <summary>
        /// Название соревнований
        /// </summary>
        public string CompetitionName { get; private set; } = string.Empty;
        [DisplayName("Дата соревнования")]
        /// <summary>
        /// Дата соревнований
        /// </summary>
        public DateTime CompetitionDate { get; private set; }
        [DisplayName("Адрес соревнования")]
        /// <summary>
        /// Адрес соревнований
        /// </summary>
        public string CompetitionAdress { get; private set; } = string.Empty;
        [DisplayName("Имя жокея")]
        /// <summary>
        /// Имя жокея
        /// </summary>
        public string JockeyName { get; private set; } = string.Empty;
        [DisplayName("Кличка лошади")]
        /// <summary>
        /// Кличка лощади
        /// </summary>
        public string HorseName { get; private set; } = string.Empty;
        [DisplayName("Занятое место")]
        /// <summary>
        /// Занятое место
        /// </summary>
        public int Place { get; private set; }
    }
}