using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.ProductOptions;

namespace Application.Interface
{
    public interface IProductOptionsService
    {
        Task<IEnumerable<ViewProductOption>> GetProductOptions(Guid productId);

        Task<ViewProductOption> GetProductOption(Guid productId, Guid optionId);

        Task<ViewProductOption> CreateProductOption(Guid productId, CreateProductOption createProductOption);

        Task<ViewProductOption> UpdateProductOption(Guid productId, Guid optionId,  UpdateProductOption updateProductOption);

        Task<Boolean> DeleteProductOption(Guid productId, Guid optionId);
    }
}
