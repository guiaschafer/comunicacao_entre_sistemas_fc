using GraphQL.Dotnet.WebApplication.Database;
using GraphQL.Dotnet.WebApplication.Model;

namespace GraphQL.Dotnet.WebApplication.GraphQL;

public class Mutation
{
    public async Task<Category> AddCategory(NewCategoryDto input, AppContexto appContexto)
    {
        var entity = appContexto.Categories.Add(new Category
        {
            Id = appContexto.Categories.Max(t => t.Id) + 1,
            Name = input.Name,
            Description = input.Description
        });

        appContexto.SaveChanges();

        return entity.Entity;
    }

    public async Task<Course> AddCourse(NewCourseDto input, AppContexto appContexto)
    {
        var category = appContexto.Categories.FirstOrDefault(t=> t.Id == input.CategoryId);
        var entity = appContexto.Courses.Add(new Course
        {
            Id = appContexto.Courses.Max(t => t.Id) + 1,
            Name = input.Name,
            Description = input.Description,
            Category = category
        });

        appContexto.SaveChanges();

        return entity.Entity;
    }
}

public class MutationType : ObjectType<Mutation>
{
    protected override void Configure(
       IObjectTypeDescriptor<Mutation> descriptor)
    {
        descriptor.Field(f => f.AddCategory(default, default))
        .Argument("input", a => a.Type<NewCategoryType>());


        descriptor.Field(f => f.AddCourse(default, default))
       .Argument("input", a => a.Type<NewCourseType>());
    }
}