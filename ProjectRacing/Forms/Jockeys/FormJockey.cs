using ProjectRacing.Repositories;
namespace ProjectRacing.Forms
{
    public partial class FormJockey : Form
    {
        private readonly IJockeyRepository _jockeyRepository;
        private int? _jockeyId;
        public int ID
        {
            set
            {
                try
                {
                    var jockey = _jockeyRepository.GetJockeyById(value);
                    if (jockey == null) throw new InvalidDataException(nameof(jockey));                 
                    textBoxNumberOfJockey.Text = jockey.Number;
                    numericUpDownAgeOfJockey.Value = jockey.Age;
                    textBoxNameOfJockey.Text = jockey.NameOfJockey;
                    _jockeyId = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при получении данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public FormJockey(IJockeyRepository jockeyRepository)
        {
            InitializeComponent();
            _jockeyRepository = jockeyRepository ?? throw new ArgumentNullException(nameof(jockeyRepository));
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {     
                if (string.IsNullOrWhiteSpace(textBoxNameOfJockey.Text)) throw new Exception("Имя не заполнено");
                if (string.IsNullOrWhiteSpace(textBoxNumberOfJockey.Text)) throw new Exception("Номер не заполнен");
                if (_jockeyId.HasValue)
                {
                    var updatedJockey = CreateJockey(_jockeyId.Value);
                    _jockeyRepository.UpdateJockey(updatedJockey);
                }
                else _jockeyRepository.CreateJockey(CreateJockey(0));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonExit_Click(object sender, EventArgs e) => Close();
        private Entities.Jockey CreateJockey(int id) => Entities.Jockey.CreateEntity(id, textBoxNameOfJockey.Text, (int)numericUpDownAgeOfJockey.Value, (int)numericUpDownRateOfJockey.Value, textBoxNumberOfJockey.Text);
    }
}
