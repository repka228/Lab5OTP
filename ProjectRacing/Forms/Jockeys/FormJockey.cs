using ProjectRacing.Repositories;
namespace ProjectRacing.Forms
{
    /// <summary>
    /// Форма жокея
    /// </summary>
    public partial class FormJockey : Form
    {
        /// <summary>
        /// Репозиторий жокеев
        /// </summary>
        private readonly IJockeyRepository _jockeyRepository;
        /// <summary>
        /// ID жокея
        /// </summary>
        private int? _jockeyId;
        /// <summary>
        /// Получение ID переданного жокея
        /// </summary>
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
        /// <summary>
        /// Конструктор жокея
        /// </summary>
        /// <param name="jockeyRepository">Репозиторий жокеев</param>
        /// <exception cref="ArgumentNullException">Нет репозитория</exception>
        public FormJockey(IJockeyRepository jockeyRepository)
        {
            InitializeComponent();
            _jockeyRepository = jockeyRepository ?? throw new ArgumentNullException(nameof(jockeyRepository));
        }
        /// <summary>
        /// Сохранение жокея
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Закрытие формы жокея
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, EventArgs e) => Close();
        /// <summary>
        /// Создание жокея
        /// </summary>
        /// <param name="id">ID жокея</param>
        /// <returns></returns>
        private Entities.Jockey CreateJockey(int id) => Entities.Jockey.CreateEntity(id, textBoxNameOfJockey.Text, (int)numericUpDownAgeOfJockey.Value, (int)numericUpDownRateOfJockey.Value, textBoxNumberOfJockey.Text);
    }
}
