using System.ComponentModel;
namespace ProjectRacing.Entities
{
    /// <summary>
    /// Класс владельца
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Id владельца
        /// </summary>
        public int Id { get; private set; }
        [DisplayName("Имя владельца")]
        /// <summary>
        /// Имя владельца
        /// </summary>
        public string NameOfOwner { get; private set; } = string.Empty;
        [DisplayName("Номер владельца")]
        /// <summary>
        /// Номер владельца
        /// </summary>
        public string Number { get; private set; } = string.Empty;
        [DisplayName("Адрес владельца")]
        /// <summary>
        /// Адресс владельца
        /// </summary>
        public string Adress { get; private set; } = string.Empty;
        /// <summary>
        /// Создание владельца
        /// </summary>
        /// <param name="id">Id владельца</param>
        /// <param name="nameOfOwner">Имя владельца</param>
        /// <param name="number">Номер владельца</param>
        /// <param name="adress">Адрес владельца</param>
        /// <returns></returns>
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