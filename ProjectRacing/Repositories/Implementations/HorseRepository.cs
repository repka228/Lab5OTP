using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectRacing.Entities;
using Npgsql;
namespace ProjectRacing.Repositories.Implementations
{
    public class HorseRepository(IConnectionString connectionString, ILogger<HorseRepository> logger) : IHorseRepository
    {
        private readonly IConnectionString _connectionString = connectionString;
        private readonly ILogger<HorseRepository> _logger = logger;
        public void CreateHorse(Horse horse)
        {
            _logger.LogInformation("Добавление лошади");
            _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(horse));
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                connection.Open();
                var queryInser = @"INSERT INTO Horse (NameOfHorse, Sex, Birthday, OwnerId)
            VALUES (@NameOfHorse, @Sex, @Birthday, @OwnerId)";
                connection.Execute(queryInser, horse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении лошади");
                throw;
            }
        }
        public void UpdateHorse(Horse horse)
        {
            _logger.LogInformation("Редактирование лошади");
            _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(horse));
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                connection.Open();
                var queryUpdate = @"UPDATE Horse 
                           SET NameOfHorse = @NameOfHorse, 
                               Sex = @Sex, 
                               Birthday = @Birthday, 
                               OwnerId = @OwnerId
                           WHERE Id = @Id";
                connection.Execute(queryUpdate, horse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при редактировании соревнований");
                throw;
            }
        }
        public void DeleteHorse(int id)
        {
            _logger.LogInformation("Удалений лошади");
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                connection.Open();
                var queryDelete = @"DELETE FROM Horse WHERE Id=@id";
                connection.Execute(queryDelete, new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении лошади");
                throw;
            }
        }
        public Horse GetHorseById(int id)
        {
            _logger.LogInformation("Получение лошади по ID");
            _logger.LogDebug("Объект: {id}", id);
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                var querySelect = @"SELECT * FROM Horse WHERE Id=@id";
                var horse = connection.QueryFirst<Horse>(querySelect, new { id });
                connection.Execute(querySelect, new { id });
                return horse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при поиске лошади");
                throw;
            }
        }
        public IEnumerable<Horse> GetHorses()
        {
            _logger.LogInformation("Получение всех лошадей");
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                var querySelect = @"
            SELECT 
                h.*, 
                o.NameOfOwner AS OwnerName
            FROM Horse h
            LEFT JOIN Owner o ON h.OwnerId = o.Id";

                var horses = connection.Query<Horse>(querySelect);
                _logger.LogDebug("Получение всех объектов: {json}", JsonConvert.SerializeObject(horses));
                return horses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при чтении лошадей");
                throw;
            }
        }
    }
}