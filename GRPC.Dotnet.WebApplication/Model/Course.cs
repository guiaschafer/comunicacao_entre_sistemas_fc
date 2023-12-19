using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GRPC.Dotnet.WebApplication.Model;

public class Course
{
    [Key]
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    // public Category? Category { get; set; }
}