using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Service.DTOS.ProductDTO;
using Shipping.Service.Products;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productService;

        public ProductsController(IProductServices productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductUpdateDTO productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _productService.AddAsync(productDto);
                return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new
                {
                    Error = "Mapping Error",
                    Message = ex.Message,
                    Details = ex.InnerException?.Message
                });
            }
        }
       

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDTO productDto)
        {
            if (id != productDto.Id)
                return BadRequest("ID mismatch");

            var result = await _productService.UpdateAsync(id, productDto);
            if (!result)
                return NotFound();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
