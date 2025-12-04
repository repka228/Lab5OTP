using ProjectRacing.Entities.Enums;
using System.ComponentModel;
namespace ProjectRacing.Entities
{
    public class MedicalExamination
    {
        public int Id { get; private set; }
        [DisplayName("Дата обследования")]
        public DateTime Date { get; private set; }
        [DisplayName("Статус здоровья")]
        public HealthStatus HealthStatus { get; private set; }
        [DisplayName("Кличка лошади")]
        public int HorseId { get; private set; }
        public static MedicalExamination CreateEntity(int id, DateTime date, HealthStatus healthStatus, int horseId)
        {
            return new MedicalExamination
            {
                Id = id,
                Date = date,
                HealthStatus = healthStatus,
                HorseId = horseId
            };
        }
    }
}