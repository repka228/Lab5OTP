using ProjectRacing.Repositories;
using Unity;
namespace ProjectRacing.Forms.Jockeys
{
    public partial class FormJockeys : Form
    {
        private readonly IUnityContainer _container;
        private readonly IJockeyRepository _jockeyRepository;
        public FormJockeys(IUnityContainer container, IJockeyRepository jockeyRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _jockeyRepository = jockeyRepository ?? throw new ArgumentNullException(nameof(_jockeyRepository));
        }
        private void FormJockeys_Load(object sender, EventArgs e)
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
        private void LoadList() {
            dataGridViewJockeys.DataSource = _jockeyRepository.GetJockeys();
            dataGridViewJockeys.Columns["Id"].Visible = false;
        }
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
