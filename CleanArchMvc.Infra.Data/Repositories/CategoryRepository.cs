using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public async Task<Category> CreateAsync(Category category)
    {
        context.Add(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> GetByIdAsync(int? id)
    {
        return await context.Categories.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category> RemoveAsync(Category category)
    {
        context.Remove(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        context.Update(category);
        await context.SaveChangesAsync();
        return category;
    }
}