using GeekShopping.ProductAPI.Data.ValueObject;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
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

        [HttpGet]
        public  async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _productRepository.FindAll();
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if(product.Id <= 0)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async  Task<ActionResult<ProductVO>> Create(ProductVO product)
        {
            if(product == null) { return BadRequest();}

            var prod= await _productRepository.Create(product);

            return Ok(prod);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update( ProductVO vo)
        {
            if(vo == null)
            {
                return BadRequest();
            }
            var product = await _productRepository.Update(vo);
            return Ok(product);

        }

        [HttpDelete("id")]
        public  async Task<ActionResult<ProductVO>> Delete(int id)
        {
            var status = await _productRepository.Delete(id);
            if(!status) return BadRequest();
            return Ok(status);
        }


    }
}
