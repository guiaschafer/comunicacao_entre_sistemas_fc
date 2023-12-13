
using GraphQL.Dotnet.WebApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Dotnet.WebApplication.Database;

public class AppContexto : DbContext
{
    public AppContexto(DbContextOptions<AppContexto> options) : base(options)
    {

    }


    public DbSet<Category> Categories { get; set; }
    public DbSet<Course> Courses { get; set; }
}