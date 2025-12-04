using ProjectRacing.Repositories;
using System.Data;
using Unity;
namespace ProjectRacing.Forms.Competitions
{
    /// <summary>
    /// Форма соревнований
    /// </summary>
    public partial class FormCompetitions : Form
    {
        /// <summary>
        /// Контейнер форм соревнования
        /// </summary>
        private readonly IUnityContainer _container;
        /// <summary>
        /// Репозиторий соревнований
        /// </summary>
        private readonly ICompetitionsRepository _competitionRepository;
        /// <summary>
        /// Репозиторий участников
        /// </summary>
        private readonly IParticipantsRepository _participantsRepository;
        /// <summary>
        /// Сводная таблицы всех данных
        /// </summary>
        private readonly DataTable _dataTable;
        /// <summary>
        /// Конструктор формы соревнований
        /// </summary>
        /// <param name="container">Контейнер форм соревнования</param>
        /// <param name="competitionRepository">Репозиторий соревнований</param>
        /// <param name="participantsRepository">Репозиторий участников</param>
        /// <exception cref="ArgumentNullException"></exception>
        public FormCompetitions(IUnityContainer container, ICompetitionsRepository competitionRepository, IParticipantsRepository participantsRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _competitionRepository = competitionRepository ?? throw new ArgumentNullException(nameof(competitionRepository));
            _participantsRepository = participantsRepository ?? throw new ArgumentNullException(nameof(participantsRepository));
            _dataTable = new DataTable();
            _dataTable.Columns.Add("CompetitionName", typeof(string));
            _dataTable.Columns.Add("CompetitionDate", typeof(DateTime));
            _dataTable.Columns.Add("CompetitionAdress", typeof(string));
            _dataTable.Columns.Add("JockeyName", typeof(string));
            _dataTable.Columns.Add("HorseName", typeof(string));
            _dataTable.Columns.Add("Place", typeof(int));
            dataGridViewCompetitionsAndParticipants.DataSource = _dataTable;
            dataGridViewCompetitionsAndParticipants.Columns["CompetitionName"].HeaderText = "Название Соревнования";
            dataGridViewCompetitionsAndParticipants.Columns["CompetitionDate"].HeaderText = "Дата соревнований";
            dataGridViewCompetitionsAndParticipants.Columns["CompetitionAdress"].HeaderText = "Адрес соревнований";
            dataGridViewCompetitionsAndParticipants.Columns["JockeyName"].HeaderText = "Имя жокея";
            dataGridViewCompetitionsAndParticipants.Columns["HorseName"].HeaderText = "Имя лошади";
            dataGridViewCompetitionsAndParticipants.Columns["Place"].HeaderText = "Занятое место";
            try
            {
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Добавление соревнования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormCompetition>().ShowDialog();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Удаление соревнования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromsSelectRow(out var findId)) return;          
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes) return;           
            try
            {
                _competitionRepository.DeleteCompetitions(findId);
                _participantsRepository.DeleteParticipants(findId);
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Обновление соревнования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromsSelectRow(out var findId)) return;         
            try
            {
                var form = _container.Resolve<FormCompetition>();
                form.ID = findId;
                form.ShowDialog();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при изменении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Загрузка соревнований
        /// </summary>
        private void LoadList() { 
            dataGridViewCompetitionsAndParticipants.DataSource = _competitionRepository.GetCompetitionses();
            dataGridViewCompetitionsAndParticipants.Columns["HorseID"].Visible = false;
            dataGridViewCompetitionsAndParticipants.Columns["IdCompetitions"].Visible = false;
        }
        /// <summary>
        /// Получение ID соревнований из таблицы
        /// </summary>
        /// <param name="id">ID выбранной строки</param>
        /// <returns></returns>
        private bool TryGetIdentifierFromsSelectRow(out int id)
        {
            id = 0;
            if (dataGridViewCompetitionsAndParticipants.SelectedRows.Count < 1)
            {
                MessageBox.Show("Нет выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var selectedRow = dataGridViewCompetitionsAndParticipants.SelectedRows[0];
            id = Convert.ToInt32(selectedRow.Cells["IdCompetitions"].Value);
            return true;
        }
    }
}