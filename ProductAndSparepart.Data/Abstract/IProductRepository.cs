using ProductAndSparepart.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Data.Abstract
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
       
        Task<List<Product>> GetProducts(string searchTerm);

        Task<List<Product>> GetProductsId(int id);

        Task<Product> ProductExists(string name);

         Task<Product> Update(Product product);
        

        Task<Product> ProductExistsId(int id);

    





    }
}

