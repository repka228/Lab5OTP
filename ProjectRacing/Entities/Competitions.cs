using System.ComponentModel;
namespace ProjectRacing.Entities
{
    public class Competitions
    {
        public int Id { get; set; }
        [DisplayName("Дата соревнований")]
        public DateTime DateOfCompetitions { get; set; }
        [DisplayName("Адрес соревнований")]
        public string Adress { get; set; } = string.Empty;
        [DisplayName("Название соревнований")]
        public string Name { get; set; } = string.Empty;
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