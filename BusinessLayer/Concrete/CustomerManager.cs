using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public Task<bool> AnyAsync(Expression<Func<Customer, bool>> expressions)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Customer t)
        {
            _customerDal.Add(t);
        }

        public void TDelete(Customer t)
        {
            _customerDal.Delete(t); 
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var res = await _customerDal.GetByIdAsync(id);
            return res;
        }

        public void TUpdate(Customer t)
        {
            _customerDal.Update(t);
        }

        public List<Customer> GetCustomersListWithJob()
        {
            return _customerDal.GetCustomerListWithJob();
        }
    }
}
