using GeekShooping.ProductApi._2._0.Repository.Interfaces;
using GeekShooping.ProductApi._2._0.Util;
using GeekShopping.ProductApi._2._0.Data.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.ProductApi._2._0.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product.Id == 0) return NotFound();
            return Ok(product);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var product = await _productRepository.FindAll();
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Create([FromBody] ProductVO productVo)
        {
            if (productVo == null) return BadRequest();
            var product = await _productRepository.Create(productVo);
            
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Update([FromBody] ProductVO productVo)
        {
            if (productVo == null) return BadRequest();
            var product = await _productRepository.Update(productVo);
            
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Delete(long id)
        {
            var status = await _productRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
