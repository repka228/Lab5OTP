using ProjectRacing.Repositories;
namespace ProjectRacing.Forms.Owners
{
    public partial class FormOwner : Form
    {
        private readonly IOwnerRepository _ownerRepository;
        private int? _ownerId;
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
        public FormOwner(IOwnerRepository ownerRepository)
        {
            InitializeComponent();
            _ownerRepository = ownerRepository ?? throw new ArgumentNullException(nameof(ownerRepository));
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxAdressOfOwner.Text)) throw new Exception("Адрес владельца не заполнен");
                if (string.IsNullOrWhiteSpace(textBoxNameOfOwner.Text)) throw new Exception("Имя не заполнено");
                if (string.IsNullOrWhiteSpace(textBoxNumberOfOwner.Text)) throw new Exception("Номер владельца не заполнен");
                if (_ownerId.HasValue) _ownerRepository.UpdateOwner(_ownerRepository.GetOwnerById(_ownerId.Value));               
                else _ownerRepository.CreateOwner(CreateOwner(0));            
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonExit_Click(object sender, EventArgs e) => Close();
        private Entities.Owner CreateOwner(int id) => Entities.Owner.CreateEntity(id, textBoxNameOfOwner.Text, textBoxNumberOfOwner.Text, textBoxAdressOfOwner.Text);
    }
}
