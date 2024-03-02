using MediatR;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Categories.Commands;

public class CategoryDeleteCommand : IRequest<Category>
{
    public int Id { get; set; }

    public CategoryDeleteCommand(int id)
    {
        Id = id;
    }

    public class Handler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryDeleteCommand, Category>
    {
        public async Task<Category> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id);

            if (category == null) throw new ApplicationException("Entity could be found");

            return await categoryRepository.RemoveAsync(category);
        }
    }
}