using ProjectRacing.Repositories;
using Unity;
namespace ProjectRacing.Forms
{
    public partial class FormHorses : Form
    {
        private readonly IUnityContainer _container;
        private readonly IHorseRepository _horseRepository;
        private readonly IOwnerRepository _ownerRepository;
        public FormHorses(IUnityContainer container, IHorseRepository horseRepository, IOwnerRepository ownerRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _horseRepository = horseRepository ?? throw new ArgumentNullException(nameof(horseRepository));
            _ownerRepository = ownerRepository;
        }
        private void FormHorses_Load(object sender, EventArgs e)
        {
            try
            {
                LoadList();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
        private void LoadList() {
            dataGridViewHorses.DataSource = _horseRepository.GetHorses();
            dataGridViewHorses.Columns["Id"].Visible = false;
        }
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