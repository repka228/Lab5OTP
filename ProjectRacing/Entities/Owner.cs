using System.ComponentModel;
namespace ProjectRacing.Entities
{
    public class Owner
    {
        public int Id { get; private set; }
        [DisplayName("Имя владельца")]
        public string NameOfOwner { get; private set; } = string.Empty;
        [DisplayName("Номер владельца")]
        public string Number { get; private set; } = string.Empty;
        [DisplayName("Адрес владельца")]
        public string Adress { get; private set; } = string.Empty;
        public static Owner CreateEntity(int id, string nameOfOwner, string number, string adress)
        {
            return new Owner
            {
                Id = id,
                NameOfOwner = nameOfOwner,
                Number = number,
                Adress = adress
            };
        }
    }
}