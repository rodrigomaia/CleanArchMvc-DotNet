using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands;

public class ProductCreateCommand : ProductCommand
{

    public class Handler(IProductRepository productRepository) : IRequestHandler<ProductCreateCommand, Product>
    {
        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

            if (product == null) throw new ApplicationException("Error creating entity");

            product.CategoryId = request.CategoryId;
            return await productRepository.CreateAsync(product);
        }
    }
}