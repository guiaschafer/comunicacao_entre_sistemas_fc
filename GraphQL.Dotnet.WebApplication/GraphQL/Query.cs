
using GraphQL.Dotnet.WebApplication.Database;
using GraphQL.Dotnet.WebApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Dotnet.WebApplication.GraphQL;

public class Query
{
    public IQueryable<Category> GetCategories([Service] AppContexto _context) => _context.Categories;
    public IQueryable<Category> GetCategoryById([Service] AppContexto _context, int categoryId) => _context.Categories.Include(c => c.Courses).Where(c => c.Id == categoryId);
    public IQueryable<Course> GetCourses([Service] AppContexto _context) => _context.Courses.Include(i => i.Category);
}