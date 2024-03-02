using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class CategoriesController(ICategoryService categoryService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(){
        var categories = await categoryService.GetCategoriesAsync();
        return View(categories);
    }

    [HttpGet]
    public IActionResult Create(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO categoryDTO){
        if(ModelState.IsValid){
            await categoryService.CreateAsync(categoryDTO);
            return RedirectToAction(nameof(Index));
        }
        
        return View(categoryDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id){
        if(id == null) return NotFound();
        var category = await categoryService.GetByIdAsync(id);
        if(category == null) return NotFound();

        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDTO categoryDTO){
        if(ModelState.IsValid){
            await categoryService.UpdateAsync(categoryDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(categoryDTO);
    }
}