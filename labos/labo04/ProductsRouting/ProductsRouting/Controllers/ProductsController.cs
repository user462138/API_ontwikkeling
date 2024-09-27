using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ProductsRouting.Models;
using ProductsRouting.Services;

namespace ProductsRouting.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Route("api/posts")]
//[Route("api/some-posts-whatever")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productsService;

    public ProductsController()
    {
        _productsService = new ProductsService();
    }

    [HttpGet] // api/posts
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _productsService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id:int}/details")] // api/posts/1
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productsService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    // GET /api/products/search?name={name}
    [HttpGet("search")]
    public async Task<ActionResult<List<Product>>> SearchProducts([FromQuery(Name = "name")] string name)
    {
        var products = await _productsService.SearchProductsByName(name);
        if (products == null || !products.Any())
        {
            return NotFound();
        }
        return Ok(products);
    }

    // GET /api/products/category/{categoryName}/price/{minPrice}-{maxPrice}
    [HttpGet("category/{categoryName:alpha}/price/{minPrice:decimal}-{maxPrice:decimal}")]
    public async Task<ActionResult<List<Product>>> GetProductsByCategory(string categoryName, decimal minPrice, decimal maxPrice)
    {
        var products = await _productsService.GetProductsByCategoryAndPrice(categoryName, minPrice, maxPrice);
        if (products == null || !products.Any())
        {
            return NotFound();
        }
        return Ok(products);
    }

    // POST /api/products
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        await _productsService.CreateProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // PUT /api/products/{id}
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        var updatedProduct = await _productsService.UpdateProduct(id,product);
        if (updatedProduct == null)
        {
            return NotFound();
        }

        return Ok(updatedProduct);
    }

    // PUT /api/products/{id}/discount/{percentage
    [HttpPut("{id:int}/discount/{percentage:int}")]
    public async Task<ActionResult> ApplyDiscountToProduct(int id, int percentage)
    {
        //if (_productsService.GetProductById(id))
        //{
        //    return BadRequest();
        //}
        var applyDiscountProduct = await _productsService.ApplyDiscountToProduct(id, percentage);
        if (applyDiscountProduct == null)
        {
            return NotFound();
        }

        return Ok(applyDiscountProduct);
    }

    //DELETE /api/products/{id}
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        var product = await _productsService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        await _productsService.DeleteProduct(id);
        return NoContent();
    }

    // DELETE /api/products/delete/multiple?ids=1,2,3
    [HttpDelete("delete/multiple")]
    public async Task<ActionResult> DeleteMultipleProducts([FromQuery] string ids)
    {
        var idList = ids.Split(',').Select(int.Parse).ToList();
        await _productsService.DeleteMultipleProducts(idList);
        return NoContent();
    }
}