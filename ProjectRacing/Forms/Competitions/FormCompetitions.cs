using ProjectRacing.Repositories;
using System.Data;
using Unity;
namespace ProjectRacing.Forms.Competitions
{
    public partial class FormCompetitions : Form
    {
        private readonly IUnityContainer _container;
        private readonly ICompetitionsRepository _competitionRepository;
        private readonly IParticipantsRepository _participantsRepository;
        private readonly IHorseRepository _horseRepository;
        private readonly IJockeyRepository _jockeyRepository;
        private readonly DataTable _dataTable;
        public FormCompetitions(IUnityContainer container, ICompetitionsRepository competitionRepository, IParticipantsRepository participantsRepository, IHorseRepository horseRepository, IJockeyRepository jockeyRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _competitionRepository = competitionRepository ?? throw new ArgumentNullException(nameof(competitionRepository));
            _participantsRepository = participantsRepository ?? throw new ArgumentNullException(nameof(participantsRepository));
            _horseRepository = horseRepository ?? throw new ArgumentNullException(nameof(horseRepository));
            _jockeyRepository = jockeyRepository ?? throw new ArgumentNullException(nameof(jockeyRepository));
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
        }
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

        private void LoadList() { 
            dataGridViewCompetitionsAndParticipants.DataSource = _competitionRepository.GetCompetitionses();
            dataGridViewCompetitionsAndParticipants.Columns["HorseID"].Visible = false;
            dataGridViewCompetitionsAndParticipants.Columns["IdCompetitions"].Visible = false;
        }
        private bool TryGetIdentifierFromsSelectRow(out int id)
        {
            id = 0;
            if (dataGridViewCompetitionsAndParticipants.SelectedRows.Count < 1)
            {
                MessageBox.Show("Нет выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            id = Convert.ToInt32(dataGridViewCompetitionsAndParticipants.SelectedRows[0].Cells["CompetitionId"].Value);
            return true;
        }
        private void FormCompetitions_Load_1(object sender, EventArgs e)
        {
            try
            {
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}