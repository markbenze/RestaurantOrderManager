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
            var tables = await _tableService.GetTablesAsync();
            return Ok(tables);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTableAsync(int id) {
            var table = await _tableService.GetTableAsync(id);
            if (table == null) {
                return NotFound();
            }
            return Ok(table);
        }

        [HttpPost]
        public async Task<ActionResult<Table>> AddTableAsync([FromBody] Table table)
        {
            var created = await _tableService.AddTableAsync(table);
            return Created(string.Empty, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTableAsync(int id)
        {
            var removed = await _tableService.RemoveTableAsync(id);

            if (!removed) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
