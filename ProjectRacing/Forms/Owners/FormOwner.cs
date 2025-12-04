using ProjectRacing.Repositories;
namespace ProjectRacing.Forms.Owners
{
    /// <summary>
    /// Форма владельца
    /// </summary>
    public partial class FormOwner : Form
    {
        /// <summary>
        /// Репозиторий владельцев
        /// </summary>
        private readonly IOwnerRepository _ownerRepository;
        /// <summary>
        /// Id владельца
        /// </summary>
        private int? _ownerId;
        /// <summary>
        /// Id переданного владельца
        /// </summary>
        public int ID
        {
            set
            {
                try
                {
                    var owner = _ownerRepository.GetOwnerById(value);
                    if (owner == null) throw new InvalidDataException(nameof(owner));                
                    textBoxAdressOfOwner.Text = owner.Adress;
                    textBoxNameOfOwner.Text = owner.NameOfOwner;
                    textBoxNumberOfOwner.Text = owner.Number;
                    _ownerId = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Конструктор формы владельца
        /// </summary>
        /// <param name="ownerRepository">Репозиторий владельца</param>
        /// <exception cref="ArgumentNullException">Нет репозитория владельца</exception>
        public FormOwner(IOwnerRepository ownerRepository)
        {
            InitializeComponent();
            _ownerRepository = ownerRepository ?? throw new ArgumentNullException(nameof(ownerRepository));
        }
        /// <summary>
        /// Сохранение владельца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxAdressOfOwner.Text)) throw new Exception("Адрес владельца не заполнен");
                if (string.IsNullOrWhiteSpace(textBoxNameOfOwner.Text)) throw new Exception("Имя не заполнено");
                if (string.IsNullOrWhiteSpace(textBoxNumberOfOwner.Text)) throw new Exception("Номер владельца не заполнен");
                if (_ownerId.HasValue)
                {
                    var updatedOwner = CreateOwner(_ownerId.Value);
                    _ownerRepository.UpdateOwner(updatedOwner);
                }
                else _ownerRepository.CreateOwner(CreateOwner(0));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Выход из формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, EventArgs e) => Close();
        /// <summary>
        /// Создание владельца
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Entities.Owner CreateOwner(int id) => Entities.Owner.CreateEntity(id, textBoxNameOfOwner.Text, textBoxNumberOfOwner.Text, textBoxAdressOfOwner.Text);
    }
}
