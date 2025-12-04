using ProjectRacing.Forms.Owners;
using ProjectRacing.Repositories;
using Unity;
namespace ProjectRacing.Forms
{
    /// <summary>
    /// Форма владельцев
    /// </summary>
    public partial class FormOwners : Form
    {
        /// <summary>
        /// Контейнер формы владельца
        /// </summary>
        private readonly IUnityContainer _container;
        /// <summary>
        /// Репозиторий владельца
        /// </summary>
        private readonly IOwnerRepository _ownerRepository;
        /// <summary>
        /// Конструктор формы владельцев
        /// </summary>
        /// <param name="container">Контейнер формы владельца</param>
        /// <param name="ownerRepository">Репозиторий владельцев</param>
        /// <exception cref="ArgumentNullException">Нет контейнера</exception>
        public FormOwners(IUnityContainer container, IOwnerRepository ownerRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _ownerRepository = ownerRepository ?? throw new ArgumentNullException(nameof(ownerRepository));
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
        /// Добавление владельца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormOwner>().ShowDialog();
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
        /// Удаление владельца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromsSelectRow(out var findId)) return;           
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes) return;       
            try
            {
                _ownerRepository.DeleteOwner(findId);
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Обновление владельца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromsSelectRow(out var findId)) return;            
            try
            {
                var form = _container.Resolve<FormOwner>();
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
        /// Загрузка владельцев
        /// </summary>
        private void LoadList() {
            dataGridViewOwners.DataSource = _ownerRepository.GetOwners();
            dataGridViewOwners.Columns["Id"].Visible = false;
        }
        /// <summary>
        /// Получения ID владельца из таблицы
        /// </summary>
        /// <param name="id">Id выбранной строки</param>
        /// <returns></returns>
        private bool TryGetIdentifierFromsSelectRow(out int id)
        {
            id = 0;
            if (dataGridViewOwners.SelectedRows.Count < 1)
            {
                MessageBox.Show("Нет выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            id = Convert.ToInt32(dataGridViewOwners.SelectedRows[0].Cells["Id"].Value);
            return true;
        }
    }
}
