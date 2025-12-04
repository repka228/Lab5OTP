using ProjectRacing.Forms;
using ProjectRacing.Forms.Competitions;
using ProjectRacing.Forms.Jockeys;
using ProjectRacing.Forms.MedicalExamination;
using Unity;
namespace ProjectRacing
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class FormRacing : Form
    {
        /// <summary>
        /// Контейнер форм
        /// </summary>
        private readonly IUnityContainer _container;
        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        /// <param name="container">Контейнер форм</param>
        /// <exception cref="ArgumentNullException">Контейнера нет</exception>
        public FormRacing(IUnityContainer container)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }
        /// <summary>
        /// Открытие формы лошадей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HorsesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormHorses>().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Открытие формы владелцьа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OwnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormOwners>().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Открытие формы жокеев
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JockeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormJockeys>().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Открытие формы соревнований
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationCompetitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormCompetitions>().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Открытие формы медицинских обследований
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteMedicalExaminationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormMedicalExaminations>().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
