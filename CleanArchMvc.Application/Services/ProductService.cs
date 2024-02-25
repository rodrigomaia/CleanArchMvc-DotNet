using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;

public class ProductService(IMapper mapper, IProductRepository productRepository) : IProductService
{
    public async Task CreateAsync(ProductDTO productDto)
    {
        var product = mapper.Map<Product>(productDto);
        await productRepository.CreateAsync(product);
    }

    public async Task<ProductDTO> GetByIdAsync(int? id)
    {
        var product = await productRepository.GetByIdAsync(id);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> GetProductCategoryAsync(int? id)
    {
        var product = await productRepository.GetProductCategoryAsync(id);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var products = await productRepository.GetProductsAsync();
        return mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task RemoveAsync(int? id)
    {
        var product = productRepository.GetByIdAsync(id).Result;
    }

    public async Task UpdateAsync(ProductDTO productDto)
    {
        var product = mapper.Map<Product>(productDto);
        await productRepository.UpdateAsync(product);
    }
}