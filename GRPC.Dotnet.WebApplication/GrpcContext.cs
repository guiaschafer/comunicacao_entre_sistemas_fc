using GRPC.Dotnet.WebApplication.Model;
using Microsoft.EntityFrameworkCore;

public class GrpcContext : DbContext
{
    public GrpcContext(DbContextOptions<GrpcContext> options) : base(options)
    {

    }


    public DbSet<Category> Categories { get; set; }
    public DbSet<Course> Courses { get; set; }

}