namespace GraphQL.Dotnet.WebApplication.Model;

public class Course
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Category? Category { get; set; }
}