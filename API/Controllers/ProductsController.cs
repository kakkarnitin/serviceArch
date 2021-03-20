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
        private readonly IProductOptionsService _productOptionsService;

        public ProductsController(ILogger<ProductsController> logger, IProductsService productsService, IProductOptionsService productOptionsService)
        {
            _logger = logger;
            _productsService = productsService;
            _productOptionsService = productOptionsService;
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
                return Ok(product);
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
        public async Task<ActionResult<IEnumerable<ViewProductOption>>> GetProductOptions(Guid id)
        {
            try
            {
                return Ok(await _productOptionsService.GetProductOptions(id));
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
        /// <returns> Product option with given id</returns>
        [HttpGet]
        [Route("{id}/options/{optionId}")]
        public async Task<ActionResult<ViewProductOption>> GetProductOption(Guid id, Guid optionId)
        {
            try
            {
                var productOption = await _productOptionsService.GetProductOption(id, optionId);

                if (productOption == null)
                {
                    return BadRequest();
                }
                return Ok(productOption);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ApiResponse { Result = 1, Message = ex.Message });
            }
        }

        /// <summary>
        ///  Create product option
        /// </summary>
        /// <returns> Product with given id</returns>
        [HttpPost]
        [Route("{id}/options")]
        public async Task<ActionResult<ViewProductOption>> CreateProductOption(Guid id, CreateProductOption createProductOption)
        {
            try
            {
                var productOption = await _productOptionsService.CreateProductOption(id, createProductOption);
                return Ok(productOption);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ApiResponse { Result = 1, Message = ex.Message });
            }
        }

        /// <summary>
        ///  Edit product option
        /// </summary>
        /// <returns> Product with given id</returns>
        [HttpPut]
        [Route("{id}/options/{optionId}")]
        public async Task<ActionResult<ViewProductOption>> UpdateProductOption(Guid id, Guid optionId, UpdateProductOption updateProductOption)
        {
            try
            {
                var productOption = await _productOptionsService.GetProductOption(id, optionId);

                if (productOption == null)
                {
                    return NotFound();
                }


                var updatedProductOption = await _productOptionsService.UpdateProductOption(id, optionId, updateProductOption);
                return Ok(updatedProductOption);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ApiResponse { Result = 1, Message = ex.Message });
            }
        }

        /// <summary>
        ///  Delete product option
        /// </summary>
        /// <returns> Return success/ failure</returns>
        [HttpDelete]
        [Route("{id}/options/{optionId}")]
        public async Task<ActionResult<bool>> DeleteProductOption(Guid id, Guid optionId)
        {
            try
            {
                var productOption = await _productOptionsService.GetProductOption(id, optionId);

                if (productOption == null)
                {
                    return NotFound();
                }


                var result = await _productOptionsService.DeleteProductOption(id, optionId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, new ApiResponse { Result = 1, Message = ex.Message });
            }
        }
    }
}
