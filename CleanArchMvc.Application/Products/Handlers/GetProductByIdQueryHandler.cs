
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.Products.Queries;
using MediatR;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Products.Handlers;

public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await productRepository.GetByIdAsync(request.Id);
    }
}