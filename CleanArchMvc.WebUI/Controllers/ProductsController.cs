using Microsoft.AspNetCore.Mvc;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController(IProductService productService, ICategoryService categoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var products = await productService.GetProductsAsync();

        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryId = new SelectList(await categoryService.GetCategoriesAsync(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDTO productDTO)
    {
        ModelState.Remove("Category");
        if (ModelState.IsValid)
        {
            await productService.CreateAsync(productDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(productDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var product = await productService.GetByIdAsync(id);
        if (product == null) return NotFound();

        ViewBag.CategoryId = new SelectList(await categoryService.GetCategoriesAsync(), "Id", "Name", product.CategoryId);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDTO productDTO)
    {
        ModelState.Remove("Category");
        if (ModelState.IsValid)
        {
            await productService.UpdateAsync(productDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(productDTO);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        var product = await productService.GetByIdAsync(id);

        return View(product);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        await productService.RemoveAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int? id)
    {
        var product = await productService.GetByIdAsync(id);

        return View(product);
    }
}