namespace Refactoring.HelperClasses;

public class DbConnection
{
    public string ConnectionString { get; }

    public DbConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public T RunCommand<T>(string query)
    {
        return default(T);
    }
}