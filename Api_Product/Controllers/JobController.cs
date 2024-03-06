using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        JobManager jobManager = new JobManager(new EntityFrameworkJobDal());

        [HttpGet]
        public IActionResult GetAllJob()
        {
            var snc = jobManager.TGetAll();
            return Ok(snc);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var snc = await jobManager.GetByIdAsync(id);
            return Ok(snc);
        }

        [HttpPost]
        public IActionResult PostJob([FromBody] Job job)
        {
            jobManager.TAdd(job);
            var snc = jobManager.GetByIdAsync(job.JobID);
            return Ok(snc);
        }

        [HttpPut]
        public IActionResult PutJob([FromBody] Job job)
        {
            jobManager.TUpdate(job);
            var snc = jobManager.GetByIdAsync(job.JobID);
            return Ok(snc);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var value = await jobManager.GetByIdAsync(id);
            jobManager.TDelete(value);
            var snc = jobManager.TGetAll();
            return Ok(snc);
        }
    }
}
