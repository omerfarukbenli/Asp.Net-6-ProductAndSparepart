using ProductAndSparepart.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Data.Abstract
{
    public interface ISparepartRepository
    {
        Task AddSparepart<T>(T entity) where T : class;

        Task<Sparepart> GetSparepart(int id);

        Task<Sparepart> GetProductWithSparepart(int id);
        Task AddProductSparepart(int id, int cat);

        Task<bool> SaveAll();
    }
}
