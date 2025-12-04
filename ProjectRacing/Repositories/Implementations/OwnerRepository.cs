using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectRacing.Entities;
using Npgsql;
namespace ProjectRacing.Repositories.Implementations
{
    public class OwnerRepository(IConnectionString connectionString, ILogger<OwnerRepository> logger) : IOwnerRepository
    {
        private readonly IConnectionString _connectionString = connectionString;
        private readonly ILogger<OwnerRepository> _logger = logger;
        public void CreateOwner(Owner owner)
        {
            _logger.LogInformation("Добавление владельца");
            _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(owner));
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                connection.Open();
                var queryInser = @"INSERT INTO Owner (NameOfOwner, Number, Adress)
            VALUES (@NameOfOwner, @Number, @Adress)";
                connection.Execute(queryInser, owner);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении владельца");
                throw;
            }
        }
        public void UpdateOwner(Owner owner)
        {
            _logger.LogInformation("Редактирование владельца");
            _logger.LogDebug("Объект: {json}", JsonConvert.SerializeObject(owner));
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                connection.Open();
                var queryUpdate = @"UPDATE Owner 
                           SET nameofowner = @NameOfOwner, 
                               number = @Number, 
                               adress = @Adress
                           WHERE id = @Id";
                _logger.LogDebug("Параметры: Id={Id}, NameOfOwner={Name}, Number={Num}, Adress={Addr}",
                owner.Id, owner.NameOfOwner, owner.Number, owner.Adress);
                connection.Execute(queryUpdate, owner);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при редактировании владельца");
                throw;
            }
        }
        public void DeleteOwner(int id)
        {
            _logger.LogInformation("Удаление владельца");
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                connection.Open();
                var queryDelete = @"DELETE FROM Owner WHERE Id=@id";
                connection.Execute(queryDelete, new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении владельца");
                throw;
            }
        }
        public Owner GetOwnerById(int id)
        {
            _logger.LogInformation("Получение владельца по ID");
            _logger.LogDebug("Объект: {id}", id);
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                var querySelect = @"SELECT * FROM Owner WHERE Id=@id";
                var owner = connection.QueryFirst<Owner>(querySelect, new { id });
                connection.Execute(querySelect, new { id });
                return owner;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при поиске вдалельца");
                throw;
            }
        }
        public IEnumerable<Owner> GetOwners()
        {
            _logger.LogInformation("Получение всех владельцев");
            try
            {
                using var connection = new NpgsqlConnection(_connectionString.ConnectionString);
                var querySelect = @"SELECT * FROM Owner";
                var owners = connection.Query<Owner>(querySelect);
                _logger.LogDebug("Получение всех объектов: {json}", JsonConvert.SerializeObject(owners));
                return owners;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при чтении владельцев");
                throw;
            }
        }
    }
}