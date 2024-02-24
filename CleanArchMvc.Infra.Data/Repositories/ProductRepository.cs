using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task<Product> CreateAsync(Product product)
    {
        context.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetByIdAsync(int? id)
    {
        return await context.Products.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Product> GetProductCategoryAsync(int? id)
    {
        return await context.Products
                .Include(e => e.Category)
                .SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        context.Remove(product);
        await context.SaveChangesAsync();
        return product;

    }

    public async Task<Product> UpdateAsync(Product product)
    {
        context.Update(product);
        await context.SaveChangesAsync();
        return product;

    }
}