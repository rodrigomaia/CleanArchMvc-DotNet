using Microsoft.AspNetCore.Mvc;
using CleanArchMvc.Application.Interfaces;

public class ProductsController(IProductService productService) : Controller
{
    public async Task<IActionResult> Index(){
        var products = await productService.GetProductsAsync();

        return View(products);
    }
    
}