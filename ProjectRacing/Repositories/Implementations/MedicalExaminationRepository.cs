using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectRacing.Entities;
using Npgsql;
namespace ProjectRacing.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий медицинских обследований
    /// </summary>
    /// <param name="connectionString">Строка подключения к БД</param>
    /// <param name="logger">Логгер</param>
    /// <param name="horseRepository">Репозиторий лошадей</param>
    public class MedicalExaminationRepository(IConnectionString connectionString, ILogger<MedicalExaminationRepository> logger, IHorseRepository horseRepository) : IMedicalExaminationRepository
    {
        private readonly IConnectionString _connectionString = connectionString;
        private readonly ILogger<MedicalExaminationRepository> _logger = logger;
        private readonly IHorseRepository _horseRepository = horseRepository;
        public void CreateMedicalExamination(MedicalExamination medicalExamination)
        {
            _logger.LogInformation("Добавление медосмотра");
            _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(medicalExamination));
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                connection.Open();
                var queryInser = @"INSERT INTO MedicalExamination (Date, HealthStatus, HorseId)
            VALUES (@Date, @HealthStatus, @HorseId)";
                connection.Execute(queryInser, medicalExamination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении медосмотра");
                throw;
            }
        }
        public void UpdateMedicalExamination(MedicalExamination medicalExamination)
        {
            _logger.LogInformation("Редактирование медосмотра");
            _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(medicalExamination));
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                connection.Open();
                var queryUpdate = @"UPDATE MedicalExamination (Date, HealthStatus, HorseId)
            VALUES (@Date, @HealthStatus, @HorseId)";
                connection.Execute(queryUpdate, medicalExamination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при редактировании медосмотра");
                throw;
            }
        }
        public void DeleteMedicalExamination(int id)
        {
            _logger.LogInformation("Удаление медосмотра");
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                connection.Open();
                var queryDelete = @"DELETE FROM MedicalExamination WHERE Id=@id";
                connection.Execute(queryDelete, new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении медосмотра");
                throw;
            }
        }
        public MedicalExamination GetMedicalExaminationById(int id)
        {
            _logger.LogInformation("Получение медосмотра по ID");
            _logger.LogDebug("Объект: {id}", id);
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                var querySelect = @"SELECT * FROM MedicalExamination WHERE Id=@id";
                var medicalExaminations = connection.QueryFirst<MedicalExamination>(querySelect, new { id });
                connection.Execute(querySelect, new { id });
                return medicalExaminations;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при поиске медосмотра");
                throw;
            }
        }
        public IEnumerable<MedicalExamination> GetMedicalExaminations()
        {
            _logger.LogInformation("Получение всех медосмотров");
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                var querySelect = @"SELECT * FROM MedicalExamination";
                var medicalExaminations = connection.Query<MedicalExamination>(querySelect);
                _logger.LogDebug("Получение всех объектов: {json}", JsonConvert.SerializeObject(medicalExaminations));
                return medicalExaminations;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при чтении медосмотров");
                throw;
            }
        }
    }
}