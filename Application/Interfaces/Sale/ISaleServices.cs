using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleServices
{
    Task<SaleResponse> CreateSale(SaleRequest request);
    Task<List<SaleGetResponse>> GetListSales(DateTime? from, DateTime? to);
    Task<Sale> GetSaleById(int saleId);
    Task<SaleResponse> GetSaleDetails(int id);
}
