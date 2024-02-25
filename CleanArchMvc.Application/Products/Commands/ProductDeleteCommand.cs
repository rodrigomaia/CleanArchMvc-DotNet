using MediatR;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Products.Commands;

public class ProductDeleteCommand : IRequest<Product>
{
    public int Id { get; set; }

    public ProductDeleteCommand(int id)
    {
        Id = id;
    }

    public class Handler(IProductRepository productRepository) : IRequestHandler<ProductDeleteCommand, Product>
    {
        public async Task<Product> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product == null) throw new ApplicationException("Entity could be found");

            return await productRepository.RemoveAsync(product);
        }
    }
}