using ProjectRacing.Entities.Enums;
using ProjectRacing.Repositories;
namespace ProjectRacing.Forms.MedicalExamination
{
    /// <summary>
    /// Форма медицинского обследования
    /// </summary>
    public partial class FormMedicalExamination : Form
    {
        /// <summary>
        /// Репозиторий медицинских обследований
        /// </summary>
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        /// <summary>
        /// 
        /// </summary>
        private int? _medicalExaminationId;
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="horseRepository"></param>
        /// <param name="medicalExamination"></param>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (_medicalExaminationId.HasValue)
                {
                    var updatedmedicalExamination = CreateMedicalExamination(_medicalExaminationId.Value);
                    _medicalExaminationRepository.UpdateMedicalExamination(updatedmedicalExamination);
                }
                else _medicalExaminationRepository.CreateMedicalExamination(CreateMedicalExamination(0));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, EventArgs e) => Close();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Entities.MedicalExamination CreateMedicalExamination(int id) => Entities.MedicalExamination.CreateEntity(id,dateTimePickerMedicalExamination.Value,(HealthStatus)comboBoxResult.SelectedIndex!, (int)comboBoxHorses.SelectedValue!);
    }
}