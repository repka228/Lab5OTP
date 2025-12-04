using ProjectRacing.Entities;
using ProjectRacing.Repositories;
namespace ProjectRacing.Forms
{
    /// <summary>
    /// Форма соревнования
    /// </summary>
    public partial class FormCompetition : Form
    {
        /// <summary>
        /// Репозиторий соревнований
        /// </summary>
        private readonly ICompetitionsRepository _competitionRepository;
        /// <summary>
        /// Репозиторий участников
        /// </summary>
        private readonly IParticipantsRepository _participantsRepository;
        /// <summary>
        /// Репозиторий лошадей
        /// </summary>
        private readonly IHorseRepository _horseRepository;
        /// <summary>
        /// Репозиторий жокеев
        /// </summary>
        private readonly IJockeyRepository _jockeyRepository;
        /// <summary>
        /// ID участников
        /// </summary>
        private int? _participantsId;
        /// <summary>
        /// ID соревнований
        /// </summary>
        private int? _competitionId;
        /// <summary>
        /// ID всех
        /// </summary>
        public int ID
        {
            set
            {
                try
                {
                    var competition = _competitionRepository.GetCompetitionById(value);
                    if (competition == null) throw new InvalidDataException(nameof(competition));                   
                    textBoxNameOfCompetition.Text = competition.Name;
                    dateTimePickerDateOfCompetition.Text = competition.DateOfCompetitions.ToString();
                    _competitionId = value;
                    var participants = _participantsRepository.GetParticipantsByCompetitionId(value);
                    if (participants == null) throw new InvalidDataException(nameof(participants));                 
                    comboBoxJockeys.DataSource = _jockeyRepository.GetJockeys();
                    comboBoxHorses.DataSource = _horseRepository.GetHorses();
                    _participantsId = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Конструктор формы соревнования
        /// </summary>
        /// <param name="competitionRepository">Репозиторий соревнований</param>
        /// <param name="participantsRepository">Репозиторий участников</param>
        /// <param name="jockeyRepository">Репозиторий жокеев</param>
        /// <param name="horseRepository">Репозиторий лошадей</param>
        /// <exception cref="ArgumentNullException">Нет репозитория</exception>
        public FormCompetition(ICompetitionsRepository competitionRepository, IParticipantsRepository participantsRepository, IJockeyRepository jockeyRepository, IHorseRepository horseRepository)
        {
            InitializeComponent();
            _competitionRepository = competitionRepository ?? throw new ArgumentNullException(nameof(competitionRepository));
            _participantsRepository = participantsRepository ?? throw new ArgumentNullException( nameof(participantsRepository));
            _horseRepository = horseRepository ?? throw new ArgumentNullException( nameof(horseRepository));
            _jockeyRepository = jockeyRepository ?? throw new ArgumentNullException(nameof(jockeyRepository));
            comboBoxHorses.DataSource = horseRepository.GetHorses();
            comboBoxHorses.DisplayMember = "NameOfHorse";
            comboBoxHorses.ValueMember = "Id";
            comboBoxJockeys.DataSource = jockeyRepository.GetJockeys();
            comboBoxJockeys.DisplayMember = "NameOfJockey";
            comboBoxJockeys.ValueMember = "Id";
        }
        /// <summary>
        /// Сохранение соревнований
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNameOfCompetition.Text)) throw new Exception("Название соревнований не заполнено");
                if (string.IsNullOrWhiteSpace(textBoxAdressOfCompetition.Text)) throw new Exception("Место соревнований не заполнено");
                if (_competitionId.HasValue)
                {
                    var updatedCompetitions = CreateCompetition(_competitionId.Value);
                    _competitionRepository.UpdateCompetitions(updatedCompetitions);
                }
                else _competitionId = _competitionRepository.CreateCompetitions(CreateCompetition(0));
                if (_participantsId.HasValue)
                {
                    var updatedParticipants = CreateParticipants(_participantsId.Value);
                    _participantsRepository.UpdateParticipants(updatedParticipants);
                }
                else _participantsRepository.CreateParticipants(CreateParticipants(0));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, EventArgs e) => Close();
        /// <summary>
        /// Создание соревнований
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Entities.Competitions CreateCompetition(int id) => Entities.Competitions.CreateEntity(id, dateTimePickerDateOfCompetition.Value, textBoxAdressOfCompetition.Text, textBoxNameOfCompetition.Text);
        /// <summary>
        /// Создание участников
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Participants CreateParticipants(int id) => Participants.CreateEntity(id, (int)comboBoxJockeys.SelectedValue!,(int)comboBoxHorses.SelectedValue!, (int)_competitionId!, (int)numericUpDownPlace.Value);
    }
}
