using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class ProductService(IMapper mapper, IMediator mediator) : IProductService
{
    public async Task CreateAsync(ProductDTO productDto)
    {
        var productCommand = mapper.Map<ProductCreateCommand>(productDto);
        await mediator.Send(productCommand);
    }

    public async Task<ProductDTO> GetByIdAsync(int? id)
    {
        var result = await mediator.Send(new GetProductByIdQuery(id.Value));
        return mapper.Map<ProductDTO>(result);
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var result = await mediator.Send(new GetProductsQuery());
        return mapper.Map<IEnumerable<ProductDTO>>(result);
    }

    public async Task RemoveAsync(int? id)
    {
        await mediator.Send(new ProductDeleteCommand(id.Value));
    }

    public async Task UpdateAsync(ProductDTO productDto)
    {
        var productCommand = mapper.Map<ProductUpdateCommand>(productDto);
        await mediator.Send(productCommand);
    }
}