using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Retail;
[Route("api/[controller]")]
[ApiController]

public class ProductController : ControllerBase
{
    private readonly IProductServices _productServices;

    public ProductController(IProductServices productServices)
    {
        _productServices = productServices;
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductRequest request)
    {
        try
        {
            var result = await _productServices.CreateProduct(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception ex)
        {
            return new JsonResult(new ApiError{Message = ex.Message}){StatusCode = 409};
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetListProducts(string name = null, int offset = 0, int limit = 0)
    {
        try
        {
            var result = await _productServices.GetListProducts(name, offset, limit);
            return new JsonResult(result){StatusCode = 200};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        try
        {   
            var result = await _productServices.GetProductById(id);
            return new JsonResult(result){StatusCode = 200};
        }
        catch (Exception ex)
        {
            return new JsonResult(new ApiError{Message = ex.Message}){StatusCode = 404};
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        try{
            var result = await _productServices.DeleteProduct(id);
            return new JsonResult(result){StatusCode = 200};
        }
        catch (Exception ex)
        {
            return new JsonResult(new ApiError{Message = ex.Message}){StatusCode = 404};
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(ProductRequest request, Guid id)
    {
        try
        {
            var result = await _productServices.UpdateProduct(request, id);
            return new JsonResult(result){StatusCode = 200};
        }
        catch (Exception ex)
        {
            return new JsonResult(new ApiError{Message = ex.Message}){StatusCode = 404};
        }
    }
}
