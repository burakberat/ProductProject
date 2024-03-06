using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expressions)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Product t)
        {
            _productDal.Add(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var res = await _productDal.GetByIdAsync(id);
            return res;
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t); 
        }
    }
}
