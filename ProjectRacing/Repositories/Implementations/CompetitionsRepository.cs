using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectRacing.Entities;
using Npgsql;
namespace ProjectRacing.Repositories.Implementations;
public class CompetitionsRepository : ICompetitionsRepository
{
    private readonly IConnectionString _connectionString;
    private readonly ILogger<CompetitionsRepository> _logger;
    public CompetitionsRepository(IConnectionString connectionString, ILogger<CompetitionsRepository> logger)
    {
        _connectionString = connectionString;
        _logger = logger;
    }
    public int CreateCompetitions(Competitions competitions)
    {
        _logger.LogInformation("Добавление соревнований");
        _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(competitions));
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            connection.Open();
            var queryInsert = @"INSERT INTO Competitions (DateOfCompetitions, Adress, Name) VALUES (@DateOfCompetitions, @Adress, @Name) RETURNING Id;";
            var competitionId = connection.ExecuteScalar<int>(queryInsert, competitions);
            return competitionId;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при добавлении соревнований");
            throw;
        }
    }

    public void UpdateCompetitions(Competitions competitions)
    {
        _logger.LogInformation("Редактирование соревнований");
        _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(competitions));
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            connection.Open();
            var queryUpdate = @"UPDATE Competitions (DateOfCompetitions, Adress, Name) VALUES (@DateOfCompetitions, @Adress, @Name)";
            connection.Execute(queryUpdate, competitions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при редактировании соревнований");
            throw;
        }
    }

    public void DeleteCompetitions(int id)
    {
        _logger.LogInformation("Удалений соревнований");
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            connection.Open();
            var queryDelete = @"DELETE FROM Competitions WHERE Id=@id";
            connection.Execute(queryDelete, new {id});
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при удалении соревнований");
            throw;
        }
    }
    public Competitions GetCompetitionById(int id)
    {
        _logger.LogInformation("Получение соревнований по ID");
        _logger.LogDebug("Объект: {id}", id);
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            var querySelect = @"SELECT * FROM Competitions WHERE Id=@id";
            var competition = connection.QueryFirst<Competitions>(querySelect,new { id });
            connection.Execute(querySelect, new { id });
            return competition;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при поиске соревнований");
            throw;
        }
    }
    public IEnumerable<TempCompetitionParticipant> GetCompetitionses(DateTime? startDate = null, DateTime? endDate = null, int? horseId = null)
    {
        _logger.LogInformation("Получение всех соревнований с участниками");
        try
        {
            var builder = new QueryBuilder();
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            if (startDate.HasValue)
            {
                builder.AddCondition("c.DateOfCompetitions >= @startDate");
            }
            if (endDate.HasValue)
            {
                builder.AddCondition("c.DateOfCompetitions <= @endDate");
            }
            if (horseId.HasValue)
            {
                builder.AddCondition("h.Id = @horseId");
            }
            var query = $@"
            SELECT 
                c.Id AS IdCompetitions, 
                c.Name AS CompetitionName, 
                c.DateOfCompetitions AS CompetitionDate,
                c.Adress AS CompetitionAdress, 
                j.NameOfJockey AS JockeyName,
                h.Id AS HorseId, 
                h.NameOfHorse AS HorseName,
                p.Place
            FROM Competitions c
            JOIN Participants p ON p.CompetitionsId = c.Id
            JOIN Jockey j ON j.Id = p.JockeyId
            JOIN Horse h ON h.Id = p.HorsesId
            {builder.Build()}";
            var results = connection.Query<TempCompetitionParticipant>(query, new { startDate, endDate, horseId });
            _logger.LogDebug("Получение всех объектов: {json}", JsonConvert.SerializeObject(results));
            return results;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при чтении соревнований");
            throw;
        }
    }
}