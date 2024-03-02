using MediatR;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Categories.Commands;

public class CategoryCreateCommand : IRequest<Category>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class Handler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryCreateCommand, Category>
    {
        public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Id, request.Name);
            if (category == null) throw new ApplicationException("Error creating entity");

            return await categoryRepository.CreateAsync(category);
        }
    }
}