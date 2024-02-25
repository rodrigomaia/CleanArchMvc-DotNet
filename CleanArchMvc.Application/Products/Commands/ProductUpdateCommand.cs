using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands;

public class ProductUpdateCommand : ProductCommand
{
    public int Id { get; set; }

    public class Handler(IProductRepository productRepository) : IRequestHandler<ProductUpdateCommand, Product>
    {
        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product == null) throw new ApplicationException("Entity could be found");

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

            return await productRepository.UpdateAsync(product);
        }
    }
}