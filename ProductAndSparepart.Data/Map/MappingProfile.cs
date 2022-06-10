using AutoMapper;
using ProductAndSparepart.Entity.Dto;
using ProductAndSparepart.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Data.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductDto>();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Sparepart, CreateSparepartDto>()
                .ForMember(des => des.Products, opt =>
                opt.MapFrom(src => src.ProductWithSpareparts.Select(x => new CreateProductSparepartDto { SparepartID = x.SparepartID, ProductID = x.ProductID }
                ))).ReverseMap();
            CreateMap<Sparepart, GetSparepartForListDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.SparepartCode, opt => opt.MapFrom(src => src.SparepartCode))
                .ForMember(x => x.SparepartName, opt => opt.MapFrom(src => src.SparepartName))
                .ForMember(x => x.SparepartPrice, opt => opt.MapFrom(src => src.SparepartPrice))
                .ForMember(x => x.Products, opt => opt.MapFrom(src => src.ProductWithSpareparts.Select(x => x.Product.ProductName)));


        }
    }
}
