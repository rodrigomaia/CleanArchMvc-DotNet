using MediatR;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<Category>
{
    public int Id { get; set; }

    public GetCategoryByIdQuery(int id)
    {
        Id = id;
    }

    public class Handler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await categoryRepository.GetByIdAsync(request.Id);
        }
    }
}