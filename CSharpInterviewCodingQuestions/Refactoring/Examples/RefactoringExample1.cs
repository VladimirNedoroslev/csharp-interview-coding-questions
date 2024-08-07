using System.Net.Http.Json;
using Refactoring.HelperClasses;

namespace Refactoring.Examples;

// Your thoughts and suggestion improvements on the code below?
public class Exporter
{
    public static void ExportUsers(string filepath, string nameFilter, UserType userType)
    {
        var report = GetUsersCsv(nameFilter, userType);
        File.WriteAllText(filepath, report.Csv);
    }

    public static CsvReport GetUsersCsv(string nameFilter, UserType userType)
    {
        var result = "";

        var users = GetUsersFromDb()
            .Where(x => x.Type == userType)
            .Where(x => x.Name.ToLower().Contains(nameFilter))
            .ToArray();

        var userIds = users.Select(x => x.Id).ToArray();

        var activityDates = GetUserActivityDates(userIds);
        foreach (var user in users)
        {
            result += user.Name;
            result += ";";
            result += activityDates.First(r => r.UserId == user.Id).LastActivityDate;
            result += "\n";
        }

        return new CsvReport()
        {
            Csv = result,
            UsersCount = users.Length,
        };
    }

    private static IEnumerable<User> GetUsersFromDb()
    {
        var connection = new DbConnection("db:server:port");
        var query = "SELECT id, name, type FROM users";
        return connection.RunCommand<IEnumerable<User>>(query);
    }

    private static IReadOnlyCollection<UserActivityDate> GetUserActivityDates(IReadOnlyCollection<Guid> userIds)
    {
        var httpClient = new HttpClient();
        var content = new StringContent(userIds.ToString()!);
        var response = httpClient.PostAsync(Configuration.UserActivitiesServiceUri, content)
            .GetAwaiter().GetResult();

        var userActivityDates = response.Content
            .ReadFromJsonAsync<IReadOnlyCollection<UserActivityDate>>().Result;
        httpClient.Dispose();
        return userActivityDates;
    }

    public class User
    {
        public Guid Id { get; }
        public string Name { get; }
        public UserType Type { get; set; }
    }

    public enum UserType
    {
        Worker = 1,
        Manager = 2,
        Customer = 3
    }

    public class UserActivityDate
    {
        public Guid UserId { get; }
        public DateTime LastActivityDate { get; }
    }

    public class CsvReport
    {
        public string Csv { get; set; }
        public int UsersCount { get; set; }
    }
}