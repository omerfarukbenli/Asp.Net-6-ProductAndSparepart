using ProductAndSparepart.Entity.Dto;
using ProductAndSparepart.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Business.Abstract
{
    public interface IProductService
    {
        Task<List<GetProductDto>> GetProducts(string searchTerm);
        Task<GetProductDto> Post(CreateProductDto productDto);
        Task<List<GetProductDto>> GetProductsId(int id);
        Task<GetProductDto> Update(UpdateProductDto productDto);
     





    }
}
