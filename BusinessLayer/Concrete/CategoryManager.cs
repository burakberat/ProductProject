using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Task<bool> AnyAsync(Expression<Func<Category, bool>> expressions)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Category t)
        {
            _categoryDal.Add(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var res = await _categoryDal.GetByIdAsync(id);
            return res;
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
