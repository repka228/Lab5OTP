using ProjectRacing.Forms.Owners;
using ProjectRacing.Repositories;
using Unity;
namespace ProjectRacing.Forms
{
    public partial class FormOwners : Form
    {
        private readonly IUnityContainer _container;
        private readonly IOwnerRepository _ownerRepository;
        public FormOwners(IUnityContainer container, IOwnerRepository ownerRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _ownerRepository = ownerRepository ?? throw new ArgumentNullException(nameof(ownerRepository));
        }
        private void FormOwners_Load(object sender, EventArgs e)
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
        private void LoadList() {
            dataGridViewOwners.DataSource = _ownerRepository.GetOwners();
            dataGridViewOwners.Columns["Id"].Visible = false;
        }
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
