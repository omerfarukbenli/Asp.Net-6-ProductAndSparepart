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
    public class SparepartRepository:ISparepartRepository
    {
        private readonly DataContext _context;

        public SparepartRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddProductSparepart(int id, int cat)
        {
            var product = _context.Products.Find(cat);

            var sparepart = _context.Spareparts.FirstOrDefault(a => a.Id == id);

            ProductWithSparepart newQuestCat = new ProductWithSparepart
            {
                Product = product,
                Sparepart = sparepart
            };
            await _context.Set<ProductWithSparepart>().AddAsync(newQuestCat);
            await _context.SaveChangesAsync();
        }

        public async Task AddSparepart<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Sparepart> GetProductWithSparepart(int id)
        {
            var product = await _context.Spareparts.Include(a => a.ProductWithSpareparts).ThenInclude(a => a.Product).FirstOrDefaultAsync(q => q.Id == id);
            return product;
        }

        public async Task<Sparepart> GetSparepart(int id)
        {
            var product = await _context.Spareparts.Include(a => a.ProductWithSpareparts).FirstOrDefaultAsync(q => q.Id == id);
            return product;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
