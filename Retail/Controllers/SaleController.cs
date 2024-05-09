using System.ComponentModel;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Retail;
[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly ISaleServices _saleServices;

    public SaleController(ISaleServices saleServices)
    {
        _saleServices = saleServices;
    }
    [HttpPost]
    public async Task<IActionResult> CreateSale(SaleRequest request)
    {
        try
        {
            var result = await _saleServices.CreateSale(request);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetListSales(DateTime? from = null, DateTime? to = null)
    {
        try
        {
            var result = await _saleServices.GetListSales(from, to);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSaleById(int id)
    {
        try
        {   
            var result = await _saleServices.GetSaleDetails(id);
            return new JsonResult(result){StatusCode = 201};
        }
        catch (Exception ex)
        {
            return new JsonResult(new ApiError{Message = ex.Message}){StatusCode = 404};
        }
    }
}
