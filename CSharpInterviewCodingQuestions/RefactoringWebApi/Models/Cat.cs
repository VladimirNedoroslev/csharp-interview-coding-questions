namespace RefactoringWebApi.Models;

// no need to refactor
public class Cat
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int Age { get; set; }
    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}