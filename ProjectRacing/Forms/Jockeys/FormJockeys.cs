using ProjectRacing.Repositories;
using Unity;
namespace ProjectRacing.Forms.Jockeys
{
    /// <summary>
    /// Форма жокеев
    /// </summary>
    public partial class FormJockeys : Form
    {
        /// <summary>
        /// Контейнер форм жокея
        /// </summary>
        private readonly IUnityContainer _container;
        /// <summary>
        /// Репозиторий жокеев
        /// </summary>
        private readonly IJockeyRepository _jockeyRepository;
        /// <summary>
        /// Конструктор формы жокеев
        /// </summary>
        /// <param name="container">Контейнер форм жокея</param>
        /// <param name="jockeyRepository">Репозиторий жокеев</param>
        /// <exception cref="ArgumentNullException">Нет репозитория</exception>
        public FormJockeys(IUnityContainer container, IJockeyRepository jockeyRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _jockeyRepository = jockeyRepository ?? throw new ArgumentNullException(nameof(_jockeyRepository));
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
        /// Добавление жокея
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormJockey>().ShowDialog();
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
        /// Удаление жокея
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromsSelectRow(out var findId)) return;           
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes) return;         
            try
            {
                _jockeyRepository.DeleteJockey(findId);
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Обновление жокея
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromsSelectRow(out var findId)) return;            
            try
            {
                var form = _container.Resolve<FormJockey>();
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
        /// Загрузка жокеев
        /// </summary>
        private void LoadList() {
            dataGridViewJockeys.DataSource = _jockeyRepository.GetJockeys();
            dataGridViewJockeys.Columns["Id"].Visible = false;
        }
        /// <summary>
        /// Получения id жокея из таблицы
        /// </summary>
        /// <param name="id">ID выбранной строки</param>
        /// <returns></returns>
        private bool TryGetIdentifierFromsSelectRow(out int id)
        {
            id = 0;
            if (dataGridViewJockeys.SelectedRows.Count < 1)
            {
                MessageBox.Show("Нет выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            id = Convert.ToInt32(dataGridViewJockeys.SelectedRows[0].Cells["Id"].Value);
            return true;
        }
    }
}
