using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.Models.Product;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services
{
    public class ProductService: IProductsService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ViewProduct> CreateProduct(CreateProduct createProduct)
        {
            Product product = _mapper.Map<Product>(createProduct);

            _context.Add<Product>(product);

            await _context.SaveChangesAsync();

            var createdProduct = _mapper.Map<ViewProduct>(product);

            return createdProduct;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await _context
                .Products
                .Include(p => p.ProductOptions)
                .FirstOrDefaultAsync(p => p.Id == id);

            _context.Products.Remove(product);

            var result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }

        public async Task<ViewProduct> GetProduct(Guid id)
        {
            var product =  await _context.Products.FindAsync(id);

            return _mapper.Map<ViewProduct>(product);
        }

        public async Task<IEnumerable<ViewProduct>> GetProducts(string name)
        {
            IQueryable<Product> query = _context.Products;

            if (name != null)
            {
                query = query
                        .Where(x => x.Name == name);
            }
            var products = await query.ToListAsync();

            return _mapper.Map<List<ViewProduct>>(products);

        }

        public async Task<ViewProduct> UpdateProduct(Guid id, UpdateProduct updateProduct)
        {
            var productInDb = await _context.Products.FindAsync(id);

            _mapper.Map<UpdateProduct, Product>(updateProduct, productInDb);

            await _context.SaveChangesAsync();

            return _mapper.Map<ViewProduct>(productInDb);
            
        }
    }
}
