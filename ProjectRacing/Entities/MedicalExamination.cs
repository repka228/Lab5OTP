using ProjectRacing.Entities.Enums;
using System.ComponentModel;
namespace ProjectRacing.Entities
{
    /// <summary>
    /// Класс медицинского обследования
    /// </summary>
    public class MedicalExamination
    {
        /// <summary>
        /// Id медицинского обследования
        /// </summary>
        public int Id { get; private set; }
        [DisplayName("Дата обследования")]
        /// <summary>
        /// Дата медицинского обследования
        /// </summary>
        public DateTime Date { get; private set; }
        [DisplayName("Статус здоровья")]
        /// <summary>
        /// Состояние лошади
        /// </summary>
        public HealthStatus HealthStatus { get; private set; }
        [DisplayName("Кличка лошади")]
        /// <summary>
        /// Id лошади
        /// </summary>
        public int HorseId { get; private set; }
        /// <summary>
        /// Создание медицинского обследования
        /// </summary>
        /// <param name="id">Id медицинского обследования</param>
        /// <param name="date">Дата медицинского обследования</param>
        /// <param name="healthStatus">Состояние лощади</param>
        /// <param name="horseId">Id лошади</param>
        /// <returns></returns>
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