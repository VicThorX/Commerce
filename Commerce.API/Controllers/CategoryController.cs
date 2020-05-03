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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IMapper<CategoryModel, Category> _categoryMapper;

        public CategoryController(
            ILogger<CategoryController> logger,
            ICategoryService categoryService,
            IMapper<CategoryModel, Category> categoryMapper)
        {
            _logger = logger;
            _categoryService = categoryService;
            _categoryMapper = categoryMapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return new ObjectResult(await _categoryService.GetAll());
        }

        [HttpGet("{id:length(24)}", Name = "GetCategory")]
        public async Task<ActionResult<Category>> Get(string id)
        {
            var category = await _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create(CategoryModel categoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Creating new category named: {0}", categoryModel.Name);

                    var categoryToCreate = _categoryMapper.Map(categoryModel);
                    categoryToCreate.CreatedAt = DateTime.Now;
                    categoryToCreate.UpdateAt = DateTime.Now;

                    var createdCategory = await _categoryService.Create(categoryToCreate);

                    return CreatedAtRoute("GetCategory", new { id = createdCategory.Id }, categoryModel);
                }

                return BadRequest("Category did not pass model validation");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new category. Category object: {0}", categoryModel);
                return BadRequest(ex);
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<Category>> Update(string id, CategoryModel categoryModel)
        {
            var categoryToUpdate = await _categoryService.Get(id);

            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            _categoryMapper.Fill(categoryModel, categoryToUpdate);
            categoryToUpdate.UpdateAt = DateTime.Now;

            await _categoryService.Update(id, categoryToUpdate);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult<Category>> Delete(string id)
        {
            var category = await _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            await _categoryService.Remove(category);

            return NoContent();
        }
    }
}