using ProjectRacing.Entities;
namespace ProjectRacing.Repositories;
public interface IMedicalExaminationRepository
{
    IEnumerable<MedicalExamination> GetMedicalExaminations();
    MedicalExamination GetMedicalExaminationById(int id);
    void CreateMedicalExamination(MedicalExamination medicalExamination);
    void UpdateMedicalExamination(MedicalExamination medicalExamination);
    void DeleteMedicalExamination(int id);
}