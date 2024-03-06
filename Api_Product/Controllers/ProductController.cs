using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Product.Controllers
{
    [Route("api/[controller]")] // controller yazan yerden sonra '/[action]' yazsaydık metot adlarıyla istek yapmamız gerekirdi.
    [ApiController]
    public class ProductController : ControllerBase
    {

        ProductManager productManager = new ProductManager(new EntityFrameworkProductDal());

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var snc = productManager.TGetAll();
            return Ok(snc);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var snc = await productManager.GetByIdAsync(id);
            return Ok(snc);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(product);

            try
            {
                if (result.IsValid)
                {
                    productManager.TAdd(product);
                    var snc = productManager.GetByIdAsync(product.Id);
                    return Ok(snc);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutProduct([FromBody] Product product)
        {
            productManager.TUpdate(product);
            var snc = productManager.GetByIdAsync(product.Id);
            return Ok(snc);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var value = await productManager.GetByIdAsync(id);
            productManager.TDelete(value);
            var snc = productManager.TGetAll();
            return Ok(snc);
        }
    }
}
