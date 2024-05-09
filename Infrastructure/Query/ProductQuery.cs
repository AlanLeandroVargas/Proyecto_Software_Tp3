using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Query;

public class ProductQuery : IProductQuery
{
    private readonly RetailContext _context;

    public ProductQuery(RetailContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetListProducts(string name, int offset, int limit)
    {
        IQueryable<Product> products = _context.Products;
        if(name != null)
        {
            products = products.Where(p => p.Name.ToLower().Contains(name.ToLower()));
        }
        if(offset > 0)
        {
            products = products.Skip(offset);
        }
        if(limit > 0)
        {
            products = products.Take(limit);
        }     
        return await products.ToListAsync();
    }

    public async Task<Product> GetProductById(Guid productId)
    {
        Product? product = await _context.Products
                        .FirstOrDefaultAsync(s => s.ProductId == productId);        
        if(product == null) throw new NotFoundException("Producto no encontrado");
        return product;
    }
}
