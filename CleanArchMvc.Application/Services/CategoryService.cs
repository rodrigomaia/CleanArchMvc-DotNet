using AutoMapper;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class CategoryService(IMapper mapper, IMediator mediator) : ICategoryService
{
    public async Task CreateAsync(CategoryDTO categoryDto)
    {
        var categoryCommand = mapper.Map<CategoryCreateCommand>(categoryDto);
        await mediator.Send(categoryCommand);
    }

    public async Task<CategoryDTO> GetByIdAsync(int? id)
    {
        var category = await mediator.Send(new GetCategoryByIdQuery(id.Value));
        return mapper.Map<CategoryDTO>(category);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        var categories = await mediator.Send(new GetCategoriesQuery());
        return mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task RemoveAsync(int? id)
    {
        await mediator.Send(new CategoryDeleteCommand(id.Value));
    }

    public async Task UpdateAsync(CategoryDTO categoryDto)
    {
        var category = mapper.Map<CategoryUpdateCommand>(categoryDto);
        await mediator.Send(category);
    }
}