using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProductsAsync();
    Task<ProductDTO> GetByIdAsync(int? id);
    Task CreateAsync(ProductDTO productDto);
    Task UpdateAsync(ProductDTO productDto);
    Task RemoveAsync(int? id);
}