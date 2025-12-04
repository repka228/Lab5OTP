using ProjectRacing.Repositories;
using Unity;
namespace ProjectRacing.Forms
{
    /// <summary>
    /// Форма лошадей
    /// </summary>
    public partial class FormHorses : Form
    {
        /// <summary>
        /// Контейнер формы лошади
        /// </summary>
        private readonly IUnityContainer _container;
        /// <summary>
        /// Репозиторий лошадей
        /// </summary>
        private readonly IHorseRepository _horseRepository;
        /// <summary>
        /// Конструктор формы лошадей
        /// </summary>
        /// <param name="container">Контейнер формы лошади</param>
        /// <param name="horseRepository">Репозиторий лошадей</param>
        /// <param name="ownerRepository">Репозиторий владельцев</param>
        /// <exception cref="ArgumentNullException">Нет репозитория</exception>
        public FormHorses(IUnityContainer container, IHorseRepository horseRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _horseRepository = horseRepository ?? throw new ArgumentNullException(nameof(horseRepository));
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
        /// Добавить лошадь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormHorse>().ShowDialog();
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
        /// Удалить лошадь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromsSelectRow(out var findId)) return;          
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes) return;        
            try
            {
                _horseRepository.DeleteHorse(findId);
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Обновить лошадь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromsSelectRow(out var findId)) return;      
            try
            {
                var form = _container.Resolve<FormHorse>();
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
        /// Загрузить лошади
        /// </summary>
        private void LoadList() {
            dataGridViewHorses.DataSource = _horseRepository.GetHorses();
            dataGridViewHorses.Columns["Id"].Visible = false;
        }
        /// <summary>
        /// Получения ID лошади из таблицы
        /// </summary>
        /// <param name="id">ID выбранной строки</param>
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