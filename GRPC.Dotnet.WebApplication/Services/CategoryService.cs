using Google.Protobuf;
using Grpc.Core;
using GRPC.Dotnet.WebApplication;
using Microsoft.EntityFrameworkCore;

namespace GRPC.Dotnet.WebApplication.Services;

public class CategoryService : CategoryServ.CategoryServBase
{
    private readonly ILogger<CategoryService> _logger;
    private readonly GrpcContext _context;
    public CategoryService(ILogger<CategoryService> logger, GrpcContext context)
    {
        _logger = logger;
        _context = context;
    }

    public override Task<CategoryReponse> CreateCategory(CreateCategoryRequest request, ServerCallContext context)
    {
        var newEntity = _context.Categories.Add(new Model.Category
        {
            Name = request.Name,
            Description = request.Description
        });
        _context.SaveChanges();

        var resp = new Category
        {
            Id = newEntity.Entity.Id.ToString(),
            Name = newEntity.Entity.Name,
            Description = newEntity.Entity.Description
        };

        return Task.FromResult(new CategoryReponse
        {
            Category = resp
        });
    }

    public override async Task<CategoryList> ListCategories(blank request, ServerCallContext context)
    {
        var listToReturn = await _context.Categories.Select(c => new Category
        {
            Id = c.Id.ToString(),
            Name = c.Name,
            Description = c.Description
        }).ToListAsync();

        var result = new CategoryList();
        listToReturn.ForEach(r => result.Categories.Add(r));

        return result;
    }

    public override async Task<Category> GetCategory(CategoryGetRequest request, ServerCallContext context)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == int.Parse(request.Id));

        var resp = new Category
        {
            Id = category.Id.ToString(),
            Name = category.Name,
            Description = category.Description
        };

        return resp;
    }

    public override async Task<CategoryList> CreateCategoryStream(IAsyncStreamReader<CreateCategoryRequest> requestStream, ServerCallContext context)
    {
        var categoriesList = new CategoryList();

        await foreach (var message in requestStream.ReadAllAsync())
        {
            var newEntity = _context.Categories.Add(new Model.Category
            {
                Name = message.Name,
                Description = message.Description
            });

            var resp = new Category
            {
                Id = newEntity.Entity.Id.ToString(),
                Name = newEntity.Entity.Name,
                Description = newEntity.Entity.Description
            };

            categoriesList.Categories.Add(resp);
        }

        _context.SaveChanges();

        return categoriesList;
    }

    public override async Task CreateCategoryStreamBirectional(IAsyncStreamReader<CreateCategoryRequest> requestStream, IServerStreamWriter<Category> responseStream, ServerCallContext context)
    {
        await foreach (var message in requestStream.ReadAllAsync())
        {
            var newEntity = _context.Categories.Add(new Model.Category
            {
                Name = message.Name,
                Description = message.Description
            });
            _context.SaveChanges();


            var resp = new Category
            {
                Id = newEntity.Entity.Id.ToString(),
                Name = newEntity.Entity.Name,
                Description = newEntity.Entity.Description
            };

            await responseStream.WriteAsync(resp);
        }
    }
}
