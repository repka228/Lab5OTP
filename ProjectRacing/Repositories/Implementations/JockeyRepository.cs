using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectRacing.Entities;
using Npgsql;
namespace ProjectRacing.Repositories.Implementations;
public class JockeyRepository(IConnectionString connectionString, ILogger<JockeyRepository> logger) : IJockeyRepository
{
    private readonly IConnectionString _connectionString = connectionString;
    private readonly ILogger<JockeyRepository> _logger = logger;
    public void CreateJockey(Jockey jockey)
    {
        _logger.LogInformation("Добавление жокея");
        _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(jockey));
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            connection.Open();
            var queryInser = @"INSERT INTO Jockey (NameOfJockey, Age, Rating, Number) VALUES (@NameOfJockey, @Age, @Rating, @Number)";
            connection.Execute(queryInser, jockey);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при добавлении жокея");
            throw;
        }
    }
    public void UpdateJockey(Jockey jockey)
    {
        _logger.LogInformation("Редактирование жокея");
        _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(jockey));
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            connection.Open();
            var queryUpdate = @"UPDATE Jockey (NameOfJockey, Age, Rating, Number) VALUES (@NameOfJockey, @Age, @Rating, @Number)";
            connection.Execute(queryUpdate, jockey);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при редактировании жокея");
            throw;
        }
    }
    public void DeleteJockey(int id)
    {
        _logger.LogInformation("Удалений жокея");
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            connection.Open();
            var queryDelete = @"DELETE FROM Jockey WHERE Id=@id";
            connection.Execute(queryDelete, new { id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при удалении жокея");
            throw;
        }
    }
    public Jockey GetJockeyById(int id)
    {
        _logger.LogInformation("Получение жокея по ID");
        _logger.LogDebug("Объект: {id}", id);
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            var querySelect = @"SELECT * FROM Jockey WHERE Id=@id";
            var jockey = connection.QueryFirst<Jockey>(querySelect, new { id });
            connection.Execute(querySelect, new { id });
            return jockey;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при поиске жокея");
            throw;
        }
    }
    public IEnumerable<Jockey> GetJockeys()
    {
        _logger.LogInformation("Получение всех жокеев");
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            var querySelect = @"SELECT * FROM Jockey";
            var jockeys = connection.Query<Jockey>(querySelect);
            _logger.LogDebug("Получение всех объектов: {json}", JsonConvert.SerializeObject(jockeys));
            return jockeys;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при чтении жокеев");
            throw;
        }
    }
}