using MediatR;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Categories.Queries;

public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
{
    public class Handler(ICategoryRepository productRepository) : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
    {
        public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetCategoriesAsync();
        }
    }
}