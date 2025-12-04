namespace ProjectRacing.Repositories
{
    /// <summary>
    /// Интерфейс строки подключения к БД
    /// </summary>
    public interface IConnectionString
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        public string ConnectionString { get; }
    }
}