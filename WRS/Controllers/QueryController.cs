using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WRS.Dtos;
using WRS.Services.Queries;

namespace WRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {

        private readonly IQueryService _queryService;
        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> CreateQuery(CreateQueryDto dto)
        {
            var query = _queryService.CreateQuery(dto);
            return Ok(query);
        }
        [HttpPost("GetAllQueries")]
        public async Task<IActionResult> GetAll()
        {
            var queries = await _queryService.GetAllQueries();
            return Ok(queries);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateQuery(UpdateQueryDto Id)
        {
            var query = await _queryService.UpdateQuery(Id);
            return Ok(query);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteQuery(int Id)
        {
            var query = await _queryService.DeleteQuery(Id);
            return Ok(query);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetQuery(int id)
        {
            var query = await _queryService.GetQuery(id);
            return Ok(query);
        }

    }
}
