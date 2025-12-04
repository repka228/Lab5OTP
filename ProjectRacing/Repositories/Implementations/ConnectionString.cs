namespace ProjectRacing.Repositories.Implementations
{
    public class ConnectionString : IConnectionString
    {
        string IConnectionString.ConnectionString => "Host=localhost;Port=5432;Username=postgres;Password=277353;Database=horseracing";
    }
}