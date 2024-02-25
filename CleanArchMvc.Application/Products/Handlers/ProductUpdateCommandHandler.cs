
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.Products.Commands;
using MediatR;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductUpdateCommandHandler(IProductRepository productRepository) : IRequestHandler<ProductUpdateCommand, Product>
{
    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id);

        if(product == null) throw new ApplicationException("Entity could be found");
        
        product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
        
        return await productRepository.UpdateAsync(product);
    }
}