using System.ComponentModel;
namespace ProjectRacing.Entities;
public class Participants
{
    public int Id { get; private set; }
    [Browsable(false)]
    public int JockeyId { get; private set; }
    [Browsable(false)]
    public int CompetitionsId { get; private set; }
    [Browsable(false)]
    public int HorsesId { get; private set; }
    [DisplayName("Занятое место")]
    public int Place {  get; private set; }
    [DisplayName("Имя жокея")]
    public string JockeyName { get; private set; } = string.Empty;
    [DisplayName("Кличка лошади")]
    public string HorseName { get; private set; } = string.Empty;
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