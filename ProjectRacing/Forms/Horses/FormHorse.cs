using ProjectRacing.Entities;
using ProjectRacing.Entities.Enums;
using ProjectRacing.Repositories;
namespace ProjectRacing.Forms
{
    public partial class FormHorse : Form
    {
        private readonly IHorseRepository _horseRepository;
        private int? _horseId;
        public int ID
        {
            set
            {
                try
                {
                    var horse = _horseRepository.GetHorseById(value);
                    if (horse == null) throw new InvalidDataException(nameof(horse));                   
                    textBoxNameOfHorse.Text = horse.NameOfHorse;
                    dateTimePickerDateOfBirthday.Text = horse.Birthday.ToString();
                    comboBoxOwner.SelectedValue = horse.OwnerId;
                    comboBoxSex.SelectedValue = horse.Sex;
                    _horseId = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }     
        public FormHorse(IHorseRepository horseRepository, IOwnerRepository ownerRepository)
        {
            InitializeComponent();
            _horseRepository = horseRepository ?? throw new ArgumentNullException(nameof(horseRepository));
            comboBoxOwner.DataSource = ownerRepository.GetOwners();
            comboBoxOwner.DisplayMember = "NameOfOwner";
            comboBoxOwner.ValueMember = "Id";   
            _ = Enum.GetValues(typeof(HealthStatus));
            var genders = Enum.GetValues(typeof(Gender));
            comboBoxSex.DisplayMember = "Name";
            foreach (var gender in genders) comboBoxSex.Items.Add(gender);           
            comboBoxSex.SelectedIndex = 0;
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBoxOwner.SelectedIndex < 0) throw new Exception("Не выбран владелец");
                if (string.IsNullOrWhiteSpace(textBoxNameOfHorse.Text)) throw new Exception("Кличка не заполнена");
                if (comboBoxSex.SelectedIndex<0) throw new Exception("Не выбран пол");
                if (_horseId.HasValue)
                {
                    var updatedHorse = CreateHorse(_horseId.Value);
                    _horseRepository.UpdateHorse(updatedHorse);
                }
                else _horseRepository.CreateHorse(CreateHorse(0));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonExit_Click(object sender, EventArgs e) => Close();
        private Horse CreateHorse(int id)=> Horse.CreateEntity(id, textBoxNameOfHorse.Text, (Gender)comboBoxSex.SelectedIndex!, dateTimePickerDateOfBirthday.Value, (int)comboBoxOwner.SelectedValue!);
    }
}