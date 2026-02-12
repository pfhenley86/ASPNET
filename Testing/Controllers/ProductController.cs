using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository repo;

    public ProductController(IProductRepository repo)
    {
        this.repo = repo;
    }
    // GET ALL
    public IActionResult Index()
    {
        var products = repo.GetAllProducts();
        return View(products);
    }
    
    // VIEW SINGLE PRODUCT
    public IActionResult ViewProduct(int id)
    {
        var product = repo.GetProduct(id);
        return View(product);
    }
    
    // VIEW Update Product Page
    public IActionResult Updateproduct(int id)
    {
        Product prod = repo.GetProduct(id);
        if (prod == null)
        {
            return View("ProductNotFound");
        }

        return View(prod);
    }
    
    // UPDATE Database Method

    public IActionResult UpdateProductToDatabase(Product product)
    {
        repo.UpdateProduct(product);
        
        return RedirectToAction("ViewProduct", new {id = product.ProductID});
    }
    
    // INSERT Product To Database

    public IActionResult InsertProduct()
    {
        var prod = repo.AssignCategory();
        return View(prod);
    }

    public IActionResult InsertProductToDatabase(Product productToInsert)
    {
        repo.InsertProduct(productToInsert);
        return RedirectToAction("Index");
    }
    
    // DELETE Products

    public IActionResult DeleteProduct(Product product)
    {
        repo.DeleteProduct(product);
        return RedirectToAction("Index");
    }
}