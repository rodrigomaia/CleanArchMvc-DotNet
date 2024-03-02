using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Categories.Commands;

public class CategoryUpdateCommand : IRequest<Category>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class Handler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryUpdateCommand, Category>
    {
        public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id);

            if (category == null) throw new ApplicationException("Entity could be found");

            category.Update(request.Name);

            return await categoryRepository.UpdateAsync(category);
        }
    }
}