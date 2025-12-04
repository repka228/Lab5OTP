using System.ComponentModel;
namespace ProjectRacing.Entities
{
    /// <summary>
    /// Класс участники
    /// </summary>
    public class Participants
    {
        /// <summary>
        /// Id участникок
        /// </summary>
        public int Id { get; private set; }
        [Browsable(false)]
        /// <summary>
        /// Id жокея
        /// </summary>
        public int JockeyId { get; private set; }
        [Browsable(false)]
        /// <summary>
        /// Id соревнований
        /// </summary>
        public int CompetitionsId { get; private set; }
        [Browsable(false)]
        /// <summary>
        /// Id лошади
        /// </summary>
        public int HorsesId { get; private set; }
        [DisplayName("Занятое место")]
        /// <summary>
        /// Занятое место
        /// </summary>
        public int Place { get; private set; }
        /// <summary>
        /// Создание участников
        /// </summary>
        /// <param name="id">Id участников</param>
        /// <param name="jockeyId">Id жокея</param>
        /// <param name="horsesId">Id лошади</param>
        /// <param name="competitionsId">Id соревнований</param>
        /// <param name="place">Занятое место</param>
        /// <returns></returns>
        public static Participants CreateEntity(int id, int jockeyId, int horsesId, int competitionsId, int place)
        {
            return new Participants
            {
                Id = id,
                JockeyId = jockeyId,
                HorsesId = horsesId,
                CompetitionsId = competitionsId,
                Place = place
            };
        }
    }
}