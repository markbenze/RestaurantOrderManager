using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderManager.Api.Services;
using RestaurantOrderManager.Shared.Models;
using System.Runtime.CompilerServices;

namespace RestaurantOrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private ITableService _tableService;

        public TableController(ITableService tableService) {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Table>>> GetTablesAsync() {
            var tables = await Task.Run(() => _tableService.GetTables());
            return Ok(tables);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableAsync(int id) {
            var table = await Task.Run(() => _tableService.GetTable(id));
            return Ok(table);
        }
    }
}
