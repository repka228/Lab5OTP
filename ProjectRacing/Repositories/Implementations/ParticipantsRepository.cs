using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectRacing.Entities;
using Npgsql;
namespace ProjectRacing.Repositories.Implementations;
public class ParticipantsRepository(IConnectionString connectionString, ILogger<ParticipantsRepository> logger) : IParticipantsRepository
{
    private readonly IConnectionString _connectionString = connectionString;
    private readonly ILogger<ParticipantsRepository> _logger = logger;
    public void CreateParticipants(Participants participants)
    {
        _logger.LogInformation("Добавились участники");
        _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(participants));
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            connection.Open();
            var queryInser = @"INSERT INTO Participants (JockeyId, CompetitionsId, HorsesId, Place) VALUES (@JockeyId, @CompetitionsId, @HorsesId, @Place)";
            connection.Execute(queryInser, participants);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при добавлении участников");
            throw;
        }
    }
    public void UpdateParticipants(Participants participants)
    {
        _logger.LogInformation("Редактирование участников");
        _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(participants));
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            connection.Open();
            var queryUpdate = @"UPDATE Participants (JockeyId, CompetitionsId, HorsesId, Place) VALUES (@JockeyId, @CompetitionsId, @HorsesId, @Place)";
            connection.Execute(queryUpdate, participants);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при редактировании участников");
            throw;
        }
    }
    public void DeleteParticipants(int id)
    {
        if (id <= 0) return;
        _logger.LogInformation("Удалений участников");
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            connection.Open();
            var queryDelete = @"DELETE FROM Participants WHERE Id=@id";
            connection.Execute(queryDelete, new { id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при удалении участников");
            throw;
        }
    }
    public IEnumerable<TempCompetitionParticipant> GetParticipants(IEnumerable<int>? competitionIds = null, int? horseId = null, DateTime? startDate = null, DateTime? endDate = null)
    {
        _logger.LogInformation("Получение участников для указанных соревнований");
        try
        {
            var builder = new QueryBuilder();
            if (competitionIds != null && competitionIds.Any()) builder.AddCondition("p.CompetitionsId = ANY(@competitionIds)");           
            if (horseId.HasValue) builder.AddCondition("h.Id = @horseId");           
            if (startDate.HasValue) builder.AddCondition("c.DateOfCompetitions >= @startDate");         
            if (endDate.HasValue) builder.AddCondition("c.DateOfCompetitions <= @endDate");          
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            var querySelect = $@"
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
            var results = connection.Query<TempCompetitionParticipant>(querySelect, new { competitionIds, horseId, startDate, endDate });
            _logger.LogDebug("Получение всех объектов: {json}", JsonConvert.SerializeObject(results));
            return results;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при чтении участников");
            throw;
        }
    }
    public Participants GetParticipantsById(int id)
    {
        _logger.LogInformation("Получение участников по ID");
        _logger.LogDebug("Объект: {id}", id);
        try
        {
            using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
            var querySelect = @"SELECT * FROM Participants WHERE Id=@id";
            var participant = connection.QueryFirst<Participants>(querySelect, new { id });
            connection.Execute(querySelect, new { id });
            return participant;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при поиске участников");
            throw;
        }
    }
}