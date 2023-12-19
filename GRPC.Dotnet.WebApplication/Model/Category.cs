using System.ComponentModel.DataAnnotations;

namespace GRPC.Dotnet.WebApplication.Model;

public class Category
{
    [Key]
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // public ICollection<Course>? Courses { get; set; }

}