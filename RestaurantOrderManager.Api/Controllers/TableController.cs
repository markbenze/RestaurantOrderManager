using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderManager.Api.Services;
using RestaurantOrderManager.Shared.Models;
using System.Runtime.CompilerServices;

namespace RestaurantOrderManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private ITableService _tableService;

        public TableController(ITableService tableService) {
            _tableService = tableService;
        }

        [Authorize(Roles ="Staff, Admin")]
        [HttpGet]
        public async Task<ActionResult<List<Table>>> GetTablesAsync() {
            var tables = await _tableService.GetTablesAsync();
            return Ok(tables);
        }

        [Authorize(Roles = "Staff, Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTableAsync(int id) {
            var table = await _tableService.GetTableAsync(id);
            if (table == null) {
                return NotFound();
            }
            return Ok(table);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Table>> AddTableAsync([FromBody] Table table)
        {
            var created = await _tableService.AddTableAsync(table);
            return Created(string.Empty, created);
        }

        [Authorize(Roles = "Admin")]
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
