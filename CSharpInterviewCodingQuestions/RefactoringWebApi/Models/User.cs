namespace RefactoringWebApi.Models;

// no need to refactor
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public List<Cat> Cats { get; set; }
}