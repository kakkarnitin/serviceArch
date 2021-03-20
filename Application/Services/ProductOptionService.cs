using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ProductOptions;
using Application.Interface;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services
{
    public class ProductOptionService : IProductOptionsService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductOptionService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ViewProductOption> CreateProductOption(Guid productId, CreateProductOption createProductOption)
        {
            ProductOptions productOption = _mapper.Map<ProductOptions>(createProductOption);

            productOption.ProductId = productId;

            _context.Add<ProductOptions>(productOption);

            await _context.SaveChangesAsync();

            var createdProductOption = _mapper.Map<ViewProductOption>(productOption);

            return createdProductOption;
        }

        public async Task<bool> DeleteProductOption(Guid productId, Guid optionId)
        {
            ProductOptions productOption = await GetOptionInDb(productId, optionId);

            _context.ProductOptions.Remove(productOption);

            var result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }

     

        public async Task<ViewProductOption> GetProductOption(Guid productId, Guid optionId)
        {
            var productOption = await GetOptionInDb(productId, optionId);

            return _mapper.Map<ViewProductOption>(productOption);
        }

        public async Task<IEnumerable<ViewProductOption>> GetProductOptions(Guid productId)
        {
            IQueryable<ProductOptions> query = _context.ProductOptions;
           
            query = query
                    .Where(x => x.ProductId == productId);
      
            var productOptions = await query.ToListAsync();

            return _mapper.Map<List<ViewProductOption>>(productOptions);
        }

        public async Task<ViewProductOption> UpdateProductOption(Guid productId, Guid optionId, UpdateProductOption updateProductOption)
        {
            var productOption = await GetOptionInDb(productId, optionId);

            _mapper.Map<UpdateProductOption, ProductOptions>(updateProductOption, productOption);

            await _context.SaveChangesAsync();

            return _mapper.Map<ViewProductOption>(productOption);
        }

        private async Task<ProductOptions> GetOptionInDb(Guid productId, Guid optionId)
        {
            IQueryable<ProductOptions> query = _context.ProductOptions;
            query = query
                    .Where(x => x.ProductId == productId)
                    .Where(x => x.Id == optionId);

            var productOption = await query.FirstOrDefaultAsync();
            return productOption;
        }
    }
}
