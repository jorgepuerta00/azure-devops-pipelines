namespace healthexplore.filters.api.Controllers
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
    public class FiltersController : Controller
    {
        private readonly IRepository<Filters> _filtersRepository;

        public FiltersController(IRepository<Filters> filtersRepository)
        {
            _filtersRepository = filtersRepository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all filters avaibles")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Get all filters succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<Filters> GetAllFilters()
        {
            return await _filtersRepository.GetAll();
        }
    }
}