using System.ComponentModel;
namespace ProjectRacing.Entities
{
    public class TempCompetitionParticipant
    {
        public int HorseId { get; private set; }
        public int IdCompetitions { get; private set; }
        [DisplayName("Название соревнования")]
        public string CompetitionName { get; private set; } = string.Empty;

        [DisplayName("Дата соревнования")]
        public DateTime CompetitionDate { get; private set; }

        [DisplayName("Адрес соревнования")]
        public string CompetitionAdress { get; private set; } = string.Empty;

        [DisplayName("Имя жокея")]
        public string JockeyName { get; private set; } = string.Empty;

        [DisplayName("Кличка лошади")]
        public string HorseName { get; private set; } = string.Empty;

        [DisplayName("Занятое место")]
        public int Place { get; private set; }
    }
}