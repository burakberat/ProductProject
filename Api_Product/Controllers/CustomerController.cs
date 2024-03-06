using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerManager customerManager = new CustomerManager(new EntityFrameworkCustomerDal());

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var snc = customerManager.GetCustomersListWithJob();
            return Ok(snc);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var snc = await customerManager.GetByIdAsync(id);
            return Ok(snc);
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            customerManager.TAdd(customer);
            var snc = customerManager.GetByIdAsync(customer.Id);
            return Ok(snc);
        }

        [HttpPut]
        public IActionResult PutCustomer([FromBody] Customer customer)
        {
            customerManager.TUpdate(customer);
            var snc = customerManager.GetByIdAsync(customer.Id);
            return Ok(snc);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var value = await customerManager.GetByIdAsync(id);
            customerManager.TDelete(value);
            var snc = customerManager.TGetAll();
            return Ok(snc);
        }
    }
}
