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
    public class JobManager : IJobService
    {
        IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public Task<bool> AnyAsync(Expression<Func<Job, bool>> expressions)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Job t)
        {
            _jobDal.Add(t);
        }

        public void TDelete(Job t )
        {
            _jobDal.Delete(t);
        }

        public List<Job> TGetAll()
        {
            return _jobDal.GetAll();
        }

        public async Task<Job> GetByIdAsync(int id)
        {
            var res = await _jobDal.GetByIdAsync(id);
            return res;
        }

        public void TUpdate(Job t)
        {
            _jobDal.Update(t);
        }
    }
}
