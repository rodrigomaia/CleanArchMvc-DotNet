using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var products = await productService.GetProductsAsync();
        if (products == null) return NotFound("Products not found");
        return Ok(products);
    }

    [HttpGet("{id}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {
        var productDTO = await productService.GetByIdAsync(id);
        if (productDTO == null) return NotFound("Product not found");
        return Ok(productDTO);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO productDTO)
    {
        if (productDTO == null) return BadRequest("Invalid data");
        await productService.CreateAsync(productDTO);

        return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDTO>> Put(int id, [FromBody] ProductDTO productDTO)
    {
        if (productDTO == null) return BadRequest("Invalid data");
        if (productDTO.Id != id) return BadRequest("Invalid data");

        await productService.UpdateAsync(productDTO);

        return Ok(productDTO);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var productDTO = await productService.GetByIdAsync(id);
        if (productDTO == null) return NotFound("Category not found");
        
        await productService.RemoveAsync(id);

        return Ok();
    }
}