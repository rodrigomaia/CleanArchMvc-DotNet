using Microsoft.AspNetCore.Mvc;
using CleanArchMvc.Application.Interfaces;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController(IProductService productService) : Controller
{
    public async Task<IActionResult> Index(){
        var products = await productService.GetProductsAsync();

        return View(products);
    }
    
}