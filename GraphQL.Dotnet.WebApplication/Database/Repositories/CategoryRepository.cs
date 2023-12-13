using GraphQL.Dotnet.WebApplication.Model;

namespace GraphQL.Dotnet.WebApplication.Database.Repositories;

public class CategoryRepository
{
    private readonly AppContexto _context;

    public CategoryRepository(AppContexto context)
    {
        _context = context;
    }

    public Category Add(Category addCategory)
    {
        var entityAdded = _context.Add(addCategory);
        _context.SaveChanges();

        return entityAdded.Entity;
    }
}