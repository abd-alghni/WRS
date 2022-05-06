using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WRS.Dtos;
using WRS.Models;
using WRS.Services.DataSources;
using WRS.ViewModels;

namespace WRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSourceController : ControllerBase
    {
        private readonly IDataSourceService _dataSourceService;
        public DataSourceController(IDataSourceService dataSourceService)
        {
            _dataSourceService = dataSourceService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddDataSource(AddDataSourceDto dto)
        {
            var dataSource = await _dataSourceService.AddDataSource(dto);
            return Ok(dataSource);
        }
        [HttpPost("GetAllDataSources")]
        public async Task<IActionResult> GetAll()
        {
            var dataSources = await _dataSourceService.GetAllDataSources();
            return Ok(dataSources);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDataSource(UpdateDataSourceDto Id)
        {
            var dataSource = await _dataSourceService.UpdateDataSource(Id);
            return Ok(dataSource);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteDataSource(int Id)
        {
            var dataSource = await _dataSourceService.DeleteDataSource(Id);
            return Ok(dataSource);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var dataSource = await _dataSourceService.GetDataSource(id);
            return Ok(dataSource);
        }
    }
}
