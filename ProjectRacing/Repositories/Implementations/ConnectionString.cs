namespace ProjectRacing.Repositories.Implementations
{
    /// <summary>
    /// Класс строки подключения к БД
    /// </summary>
    public class ConnectionString : IConnectionString
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        string IConnectionString.ConnectionString => "Host=localhost;Port=5432;Username=postgres;Password=277353;Database=horseracing";
    }
}