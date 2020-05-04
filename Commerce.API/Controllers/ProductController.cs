using Commerce.API.Mappers;
using Commerce.API.Models;
using Commerce.Data.Entities;
using Commerce.Data.Services;
using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper<ProductModel, Product> _productMapper;

        public ProductController(
            ILogger<ProductController> logger,
            IProductService productService,
            IMapper<ProductModel, Product> productMapper)
        {
            _logger = logger;
            _productService = productService;
            _productMapper = productMapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return new ObjectResult(await _productService.GetAll());
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(ProductModel productModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Creating new product named: {0}", productModel.Name);

                    var productToCreate = _productMapper.Map(productModel);
                    productToCreate.CreatedAt = DateTime.Now;
                    productToCreate.UpdateAt = DateTime.Now;

                    var createdProduct = await _productService.Create(productToCreate);

                    return CreatedAtRoute("GetProduct", new { id = createdProduct.Id }, productModel);
                }

                return BadRequest("Product did not pass model validation");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new product. Product object: {0}", productModel);
                return BadRequest(ex);
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<Product>> Update(string id, ProductModel productModel)
        {
            var productToUpdate = await _productService.Get(id);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            _productMapper.Fill(productModel, productToUpdate);
            productToUpdate.UpdateAt = DateTime.Now;

            await _productService.Update(id, productToUpdate);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult<Product>> Delete(string id)
        {
            var product = await _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productService.Remove(product);

            return NoContent();
        }
    }
}