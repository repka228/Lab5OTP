using ProjectRacing.Repositories;
using Unity;
namespace ProjectRacing.Forms.MedicalExamination
{
    /// <summary>
    /// Форма медицинских обследований
    /// </summary>
    public partial class FormMedicalExaminations : Form
    {
        /// <summary>
        /// Контейнер форм медицинского обследования
        /// </summary>
        private readonly IUnityContainer _container;
        /// <summary>
        /// Репозиторий медицинских обследований
        /// </summary>
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        /// <summary>
        /// Репозиторий лошадей
        /// </summary>
        private readonly IHorseRepository _horseRepository;
        /// <summary>
        /// Конструктор формы медицинских обследований
        /// </summary>
        /// <param name="container">Контейнер форм медининцского обследования</param>
        /// <param name="medicalExaminationRepository">Репозиторий медицинских обследований</param>
        /// <param name="horseRepository">Репозиторий лошадей</param>
        /// <exception cref="ArgumentNullException"></exception>
        public FormMedicalExaminations(IUnityContainer container, IMedicalExaminationRepository medicalExaminationRepository, IHorseRepository horseRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _medicalExaminationRepository = medicalExaminationRepository ?? throw new ArgumentNullException(nameof(medicalExaminationRepository));
            _horseRepository = horseRepository;
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
        /// Добавление медицинского обследования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormMedicalExamination>().ShowDialog();
                LoadList();
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Удаление медицинского обследования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromsSelectRow(out var findId)) return;           
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes) return;            
            try
            {
                _medicalExaminationRepository.DeleteMedicalExamination(findId);
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Обновление медицинского обследования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromsSelectRow(out var findId)) return;
            try
            {
                var form = _container.Resolve<FormMedicalExamination>();
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
        /// Загрузка медицинских обследований
        /// </summary>
        private void LoadList()
        {
            var medicalExaminations = _medicalExaminationRepository.GetMedicalExaminations();
            var medicalExaminationsWithHorseNames = medicalExaminations.Select(examination => {var horse = _horseRepository.GetHorseById(examination.HorseId); return new { examination.Id, examination.Date, examination.HealthStatus, HorseName = horse.NameOfHorse }; }).ToList();
            dataGridViewHorses.DataSource = medicalExaminationsWithHorseNames;
            dataGridViewHorses.Columns["Id"].HeaderText = "ID";
            dataGridViewHorses.Columns["Date"].HeaderText = "Дата";
            dataGridViewHorses.Columns["HealthStatus"].HeaderText = "Состояние здоровья";
            dataGridViewHorses.Columns["HorseName"].HeaderText = "Имя лошади";
            dataGridViewHorses.Columns["Id"].Visible = false;
        }
        /// <summary>
        /// Получения Id медицинского обследования из таблицы
        /// </summary>
        /// <param name="id">Id выбранной строки</param>
        /// <returns></returns>
        private bool TryGetIdentifierFromsSelectRow(out int id)
        {
            id = 0;
            if (dataGridViewHorses.SelectedRows.Count < 1)
            {
                MessageBox.Show("Нет выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            id = Convert.ToInt32(dataGridViewHorses.SelectedRows[0].Cells["Id"].Value);
            return true;
        }
    }
}
