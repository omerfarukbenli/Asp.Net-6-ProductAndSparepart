using Microsoft.EntityFrameworkCore;
using ProductAndSparepart.Data.Abstract;
using ProductAndSparepart.Data.Context;
using ProductAndSparepart.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Data.Concrete
{
    public class ProductRepository:IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

      

        public async Task<List<Product>> GetProducts(string searchTerm)
        {
            return await _context.Products.Where(a => a.ProductName.ToLower().Trim().Contains(searchTerm.ToLower()))
                                             .Take(10)
                                             .ToListAsync();
        }

        public async Task<List<Product>> GetProductsId(int id)
        {
            return await _context.Products.Where(a => a.Id == id).ToListAsync();
        }

        public async Task<Product> ProductExists(string name)
        {
            var exist = await _context.Products.FirstOrDefaultAsync(a => a.ProductName.Trim() == name.Trim());
            return exist;
        }

        public async Task<Product> ProductExistsId(int id)
        {
            var exist = await _context.Products.FirstOrDefaultAsync(a => a.Id == id);
            return exist;
        }

       
      

        public async Task<Product> Update(Product product)
        {
            _context.Set<Product>().Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

       
    }
}
