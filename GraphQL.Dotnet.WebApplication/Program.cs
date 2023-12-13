using GraphQL.Dotnet.WebApplication.Database;
using GraphQL.Dotnet.WebApplication.GraphQL;
using GraphQL.Dotnet.WebApplication.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<AppContexto>(context =>
{
    context.UseInMemoryDatabase("dotnetgraphqldatabase");

});


builder.Services
    .AddGraphQLServer()
    .AddType<CategoryType>()
    .AddType<CourseType>()
    .AddQueryType<Query>()
    .AddMutationType<MutationType>()   
    .RegisterDbContext<AppContexto>();

// builder.Services
//     .AddSingleton<NewCategory>()
//     .AddSingleton<NewCourse>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();
AppContexto db = new AppContexto(
    new DbContextOptionsBuilder<AppContexto>().UseInMemoryDatabase("dotnetgraphqldatabase").Options);

var categoryTI = new Category
{
    Id = 1,
    Name = "IT",
    Description = "Category IT"
};

var categoryBusiness = new Category
{
    Id = 2,
    Name = "Business",
    Description = "Category Business"
};

db.Categories.Add(categoryTI);
db.Categories.Add(categoryBusiness);

db.Courses.Add(new Course
{
    Id = 1,
    Name = "FC",
    Description = "Curso Full Cycle"
});
db.Courses.Add(new Course
{
    Id = 2,
    Name = "Course Business",
    Description = "Course what speak about business",
    Category = categoryBusiness
});
db.SaveChanges();
app.Run();


