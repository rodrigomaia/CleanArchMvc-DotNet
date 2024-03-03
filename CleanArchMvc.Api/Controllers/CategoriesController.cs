using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var categories = await categoryService.GetCategoriesAsync();
        if (categories == null) return NotFound("Categories not found");
        return Ok(categories);
    }

    [HttpGet("{id}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDTO>> Get(int id)
    {
        var categoryDTO = await categoryService.GetByIdAsync(id);
        if (categoryDTO == null) return NotFound("Category not found");
        return Ok(categoryDTO);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> Post([FromBody] CategoryDTO categoryDTO)
    {
        if (categoryDTO == null) return BadRequest("Invalid data");
        await categoryService.CreateAsync(categoryDTO);

        return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDTO>> Put(int id, [FromBody] CategoryDTO categoryDTO)
    {
        if (categoryDTO == null) return BadRequest("Invalid data");
        if (categoryDTO.Id != id) return BadRequest("Invalid data");

        await categoryService.UpdateAsync(categoryDTO);

        return Ok(categoryDTO);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var categoryDTO = await categoryService.GetByIdAsync(id);
        if (categoryDTO == null) return NotFound("Category not found");
        
        await categoryService.RemoveAsync(id);

        return Ok();
    }
}