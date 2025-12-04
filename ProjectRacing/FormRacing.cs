using ProjectRacing.Forms;
using ProjectRacing.Forms.Competitions;
using ProjectRacing.Forms.Jockeys;
using ProjectRacing.Forms.MedicalExamination;
using Unity;
namespace ProjectRacing
{
    public partial class FormRacing : Form
    {
        private readonly IUnityContainer _container;
        public FormRacing(IUnityContainer container)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }
        private void CompetitionToolStripMenuItem_Click(object sender, EventArgs e)
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
