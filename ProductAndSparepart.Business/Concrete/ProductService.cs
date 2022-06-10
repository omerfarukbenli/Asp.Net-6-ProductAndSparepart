using AutoMapper;
using ProductAndSparepart.Business.Abstract;
using ProductAndSparepart.Data.Abstract;
using ProductAndSparepart.Entity.Dto;
using ProductAndSparepart.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Business.Concrete
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        

        public async Task<List<GetProductDto>> GetProducts(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new ValidationException("Search term cannot be empty");
            }
            return _mapper.Map<List<GetProductDto>>(await _productRepository.GetProducts(searchTerm));
        }

        public async Task<List<GetProductDto>> GetProductsId(int id)
        {
            return _mapper.Map<List<GetProductDto>>(await _productRepository.GetProductsId(id));
        }

        public async Task<GetProductDto> Post(CreateProductDto productDto)
        {
            var category = _mapper.Map<Product>(productDto);
            var existingCat = await _productRepository.ProductExists(productDto.ProductName);
            //
            if (string.IsNullOrWhiteSpace(productDto.ProductName))
            {
                throw new ValidationException("Category name cannot be null or empty");
            }

            if (existingCat != null)
            {
                var existingCategoryForGetDto = _mapper.Map<GetProductDto>(existingCat);
                return existingCategoryForGetDto;
            }
            await _productRepository.AddProduct(category);
            var categoryForGetDto = _mapper.Map<GetProductDto>(category);
            return categoryForGetDto;
        }

        public async Task<GetProductDto> Update(UpdateProductDto productDto)
        {
            var category = _mapper.Map<Product>(productDto);

            await _productRepository.Update(category);
            var categoryForGetDto = _mapper.Map<GetProductDto>(category);
            return categoryForGetDto;
        }

      
    }
}
