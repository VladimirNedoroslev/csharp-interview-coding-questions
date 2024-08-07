using StackExchange.Redis;

namespace Refactoring.Examples;

file class UserService
{
    private readonly IDatabase _cache;

    public UserService(IDatabase cache)
    {
        _cache = cache;
    }

    public User GetUserById(string userId)
    {
        var cachedUser = _cache.StringGet(userId);
        if (cachedUser.HasValue)
        {
            return DeserializeUser(cachedUser);
        }
        
        var user = FetchUserFromDatabase(userId);
        _cache.StringSet(userId, SerializeUser(user), TimeSpan.FromMinutes(5));
        return user;
    }

    private User FetchUserFromDatabase(string userId)
    {
        return new User { Id = userId, Name = "John Doe" };
    }

    private string SerializeUser(User user)
    {
        return $"{user.Id}:{user.Name}";
    }

    private User DeserializeUser(string serializedUser)
    {
        var parts = serializedUser.Split(':');
        return new User { Id = parts[0], Name = parts[1] };
    }
}

file class User
{
    public string Id { get; set; }
    public string Name { get; set; }
}