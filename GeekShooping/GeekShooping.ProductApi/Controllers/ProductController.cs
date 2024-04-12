using GeekShooping.ProductApi.Data.ValueObjects;
using GeekShooping.ProductApi.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeekShooping.ProductApi.Controllers
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
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var product = await _productRepository.FindAll();
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Create(ProductVO productVo)
        {
            if (productVo == null) return BadRequest();
            var product = await _productRepository.Create(productVo);
            
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Update(ProductVO productVo)
        {
            if (productVo == null) return BadRequest();
            var product = await _productRepository.Update(productVo);
            
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Delete(long id)
        {
            var status = await _productRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
