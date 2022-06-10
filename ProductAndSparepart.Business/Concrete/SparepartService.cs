using AutoMapper;
using ProductAndSparepart.Business.Abstract;
using ProductAndSparepart.Data.Abstract;
using ProductAndSparepart.Entity.Dto;
using ProductAndSparepart.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Business.Concrete
{
    public class SparepartService:ISparepartService
    {
        private readonly ISparepartRepository _sparepartRepository;
        private readonly IMapper _mapper;

        public SparepartService(ISparepartRepository sparepartRepository, IMapper mapper)
        {
            _sparepartRepository = sparepartRepository;
            _mapper = mapper;
        }

        public async Task<Sparepart> AddProductAndSparepart(CreateSparepartDto aa)
        {
            var product = _mapper.Map<Sparepart>(aa);
            await _sparepartRepository.AddSparepart(product);
            foreach (var category in aa.Products)
            {
                await _sparepartRepository.AddProductSparepart(product.Id, category);
            }
            return product;
        }

        public async Task<GetSparepartForListDto> GetProductAndSparepart(int id)
        {
            return _mapper.Map<GetSparepartForListDto>(await _sparepartRepository.GetProductWithSparepart(id));
        }
    }
}
