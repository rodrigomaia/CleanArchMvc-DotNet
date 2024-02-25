
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;

public class CategoryService(IMapper mapper, ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task CreateAsync(CategoryDTO categoryDto)
    {
        var category = mapper.Map<Category>(categoryDto);
        await categoryRepository.CreateAsync(category);
    }

    public async Task<CategoryDTO> GetByIdAsync(int? id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        return mapper.Map<CategoryDTO>(category);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        var categories = await categoryRepository.GetCategoriesAsync();
        return mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task RemoveAsync(int? id)
    {
        var category = categoryRepository.GetByIdAsync(id).Result;
        await categoryRepository.RemoveAsync(category);
    }

    public async Task UpdateAsync(CategoryDTO categoryDto)
    {
        var category = mapper.Map<Category>(categoryDto);
        await categoryRepository.UpdateAsync(category);
    }
}