using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models.Product;
using Domain;

namespace Application.Interface
{
    public interface IProductsService
    {
        Task<IEnumerable<ViewProduct>> GetProducts(string name);

        Task<ViewProduct> GetProduct(Guid id);

        Task<ViewProduct> CreateProduct(CreateProduct createProduct);

        Task<ViewProduct> UpdateProduct(Guid id, UpdateProduct updateProduct);

        Task<Boolean> DeleteProduct(Guid id);

    }
}
