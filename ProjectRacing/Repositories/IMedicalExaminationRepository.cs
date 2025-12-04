using ProjectRacing.Entities;
namespace ProjectRacing.Repositories
{
    /// <summary>
    /// Интерфейс репозитория медицинского обследования
    /// </summary>
    public interface IMedicalExaminationRepository
    {
        /// <summary>
        /// Получение медицинских обследований
        /// </summary>
        /// <returns></returns>
        IEnumerable<MedicalExamination> GetMedicalExaminations();
        /// <summary>
        /// Получение медициснского обследования
        /// </summary>
        /// <param name="id">Id медицинского обследования</param>
        /// <returns></returns>
        MedicalExamination GetMedicalExaminationById(int id);
        /// <summary>
        /// Создание мединицского обследования
        /// </summary>
        /// <param name="medicalExamination">Объект медицискного обследования</param>
        void CreateMedicalExamination(MedicalExamination medicalExamination);
        /// <summary>
        /// Обновление медицинского обследования
        /// </summary>
        /// <param name="medicalExamination">Объект медицинского обследования</param>
        void UpdateMedicalExamination(MedicalExamination medicalExamination);
        /// <summary>
        /// Удаление медицинского обследования
        /// </summary>
        /// <param name="id">Id медицинского обследования</param>
        void DeleteMedicalExamination(int id);
    }
}