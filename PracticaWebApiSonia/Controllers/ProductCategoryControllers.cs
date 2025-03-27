using Microsoft.AspNetCore.Mvc;
using PracticaWebApiSonia.Interface;
using PracticaWebApiSonia.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PracticaWebApiSonia.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase  
    {
        private readonly IProductCategoryRepository _repository;

       
        public ProductCategoryController(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
        {
            var productCategories = await _repository.GetAllAsync();
            return Ok(productCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {
            var productCategory = await _repository.GetByIdAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return Ok(productCategory);
        }

        // POST: api/ProductCategory
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
        {
            await _repository.AddAsync(productCategory);
            return CreatedAtAction(nameof(GetProductCategory), new { id = productCategory.ProductCategoryID }, productCategory);
        }

        // PUT: api/ProductCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategory productCategory)
        {
            if (id != productCategory.ProductCategoryID)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync(productCategory);
            return NoContent();
        }

        // DELETE: api/ProductCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var productCategory = await _repository.GetByIdAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
