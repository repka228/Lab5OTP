using ProjectRacing.Entities.Enums;
using ProjectRacing.Repositories;
namespace ProjectRacing.Forms.MedicalExamination
{
    public partial class FormMedicalExamination : Form
    {
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        private int? _medicalExaminationId;
        public int ID
        {
            set
            {
                try
                {
                    var medicalExamination = _medicalExaminationRepository.GetMedicalExaminationById(value);
                    if (medicalExamination == null)
                    {
                        throw new InvalidDataException(nameof(medicalExamination));
                    }
                    comboBoxResult.SelectedValue = medicalExamination.HealthStatus;
                    _medicalExaminationId = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public FormMedicalExamination(IHorseRepository horseRepository, IMedicalExaminationRepository medicalExamination)
        {
            InitializeComponent();
            _medicalExaminationRepository = medicalExamination ?? throw new ArgumentNullException(nameof(horseRepository));
            comboBoxHorses.DataSource = horseRepository.GetHorses();
            comboBoxHorses.DisplayMember = "NameOfHorse";
            comboBoxHorses.ValueMember = "Id";
            var healthStatusValues = Enum.GetValues(typeof(HealthStatus));
            foreach (var value in healthStatusValues) comboBoxResult.Items.Add(value);
            comboBoxResult.SelectedIndex = 0;
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (_medicalExaminationId.HasValue) _medicalExaminationRepository.UpdateMedicalExamination(_medicalExaminationRepository.GetMedicalExaminationById(_medicalExaminationId.Value));              
                else _medicalExaminationRepository.CreateMedicalExamination(CreateMedicalExamination(0));                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonExit_Click(object sender, EventArgs e) => Close();
        private Entities.MedicalExamination CreateMedicalExamination(int id) => Entities.MedicalExamination.CreateEntity(id,dateTimePickerMedicalExamination.Value,(HealthStatus)comboBoxResult.SelectedIndex!, (int)comboBoxHorses.SelectedValue!);
    }
}