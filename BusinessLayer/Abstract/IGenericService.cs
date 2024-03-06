using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetAll();
        Task<T> GetByIdAsync(int id);
        Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<T, bool>> expressions);
    }
}
