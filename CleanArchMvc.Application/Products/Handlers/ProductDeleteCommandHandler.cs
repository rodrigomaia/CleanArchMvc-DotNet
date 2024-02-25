
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.Products.Commands;
using MediatR;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductDeleteCommandHandler(IProductRepository productRepository) : IRequestHandler<ProductDeleteCommand, Product>
{
    public async Task<Product> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id);

        if(product == null) throw new ApplicationException("Entity could be found");
        
        return await productRepository.RemoveAsync(product);
    }
}