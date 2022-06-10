using ProductAndSparepart.Entity.Dto;
using ProductAndSparepart.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Business.Abstract
{
    public interface ISparepartService
    {
        Task<Sparepart> AddProductAndSparepart(CreateSparepartDto sparepart);
        Task<GetSparepartForListDto> GetProductAndSparepart(int id);
    }
}
