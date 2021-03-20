using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.ProductOptions;
using Application.Interface;
using Application.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _productsService;

        public ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        /// <summary>
        ///  Get products
        /// </summary>
        /// <returns> A list of product</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewProduct>>> GetProducts(string name = null)
        {
            try
            {
                return Ok(await _productsService.GetProducts(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ApiResponse { Result = 1, Message = ex.Message });
            }

            
        }

        /// <summary>
        ///  Get product
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Product with given id</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ViewProduct>> GetProduct(Guid id)
        {
            try
            {
                var product = await _productsService.GetProduct(id);

                if(product == null)
                {
                    return BadRequest();
                }
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ApiResponse { Result = 1, Message = ex.Message });
            }
        }

        /// <summary>
        ///  Create product
        /// </summary>
        /// <returns> Product with given id</returns>
        [HttpPost]
        public async Task<ActionResult<ViewProduct>> CreateProduct(CreateProduct createProduct)
        {
            try
            {
                var product = await _productsService.CreateProduct(createProduct);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ApiResponse { Result = 1, Message = ex.Message });
            }
        }

        /// <summary>
        ///  Edit product
        /// </summary>
        /// <returns> Product with given id</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ViewProduct>> UpdateProduct(Guid id, UpdateProduct updateProduct)
        {
            try
            {
                var product = await _productsService.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }

                if( product.Id != id)
                {
                    return BadRequest("Product id doesn't match with the given id");
                }

                var updatedProduct = await _productsService.UpdateProduct(id, updateProduct);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ApiResponse { Result = 1, Message = ex.Message });
            }
            
        }

        /// <summary>
        ///  Delete product
        /// </summary>
        /// <returns> Return success/ failure</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(Guid id)
        {
            try
            {
                var product = await _productsService.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }


                var result = await _productsService.DeleteProduct(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ApiResponse { Result = 1, Message = ex.Message });
            }
            
        }

        /// <summary>
        ///  Get products
        /// </summary>
        /// <returns> A list of product</returns>
        [HttpGet]
        [Route("{id}/options")]
        public async Task<IEnumerable<ViewProductOption>> GetProductOptions(Guid id)
        {
            return new List<ViewProductOption>();
        }

        /// <summary>
        ///  Get product
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Product with given id</returns>
        [HttpGet]
        [Route("{id}/options/{optionId}")]
        public async Task<ViewProduct> GetProductOption(Guid id, Guid optionId)
        {
            return new ViewProduct();
        }

        /// <summary>
        ///  Create product option
        /// </summary>
        /// <returns> Product with given id</returns>
        [HttpPost]
        [Route("{id}/options")]
        public async Task<ViewProductOption> CreateProductOption(Guid id, CreateProductOption createProductOption)
        {
            return new ViewProductOption();
        }

        /// <summary>
        ///  Edit product option
        /// </summary>
        /// <returns> Product with given id</returns>
        [HttpPut]
        [Route("{id}/options/{optionId}")]
        public async Task<ViewProductOption> UpdateProductOption(Guid id, Guid optionId, UpdateProductOption updateProductOption)
        {
            return new ViewProductOption();
        }

        /// <summary>
        ///  Delete product option
        /// </summary>
        /// <returns> Return success/ failure</returns>
        [HttpDelete]
        [Route("{id}/options/{optionId}")]
        public async Task<bool> DeleteProductOption(Guid id, Guid optionId)
        {
            return true;
        }
    }
}
