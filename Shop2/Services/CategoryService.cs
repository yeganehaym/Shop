using Microsoft.EntityFrameworkCore;
using Shop2.Database;
using Shop2.Entities;
using Shop2.Entities.Dto;

namespace Shop2.Services;
/// <summary>
/// 
/// </summary>
public class CategoryService
{
    private ApplicationContext _context;

    public CategoryService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Add(Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    public async Task<List<Category>> GetParents()
    {
        return await _context
            .Categories
            .Where(x => x.ParentId.HasValue == false)
            .ToListAsync();
    }
    
    /// <summary>
    /// get children of parent
    /// </summary>
    /// <param name="id">parent Id</param>
    /// <returns></returns>
    public async Task<List<Category>> GetChildren(int id)
    {
        
        return  await _context
            .Categories
            .Where(x => x.ParentId==id)
            .ToListAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void DeleteCategory(Category cat)
    {
        _context.Categories.Remove(cat);
    }
    
    public async Task<List<CategoryFamily>> GetFamily(int id)
    {
        var cats=await _context.CategoryFamily.FromSqlInterpolated($"exec USP_Cats {id}").ToListAsync();
        return cats;
    }
}