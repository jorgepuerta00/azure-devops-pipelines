namespace healthexplore.job.api.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Repository;
    using Swashbuckle.AspNetCore.Annotations;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class JobController : Controller
    {
        private readonly IRepository<Job> _jobRepository;

        public JobController(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all jobs avaibles")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Get all jobs succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await _jobRepository.GetAll();
        }

        [HttpGet("{keyword}")]
        [SwaggerOperation(Summary = "Get all jobs avaibles")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Get all jobs succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<IEnumerable<Job>> SearchJobBykeyword(
            [SwaggerParameter(Description = "userId is a Guid Type")]
            [FromRoute] string keyword
        )
        {
            return await _jobRepository.SearchByKeyword(keyword);
        }
    }
}
