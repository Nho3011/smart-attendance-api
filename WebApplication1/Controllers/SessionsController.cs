using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionsController(ISessionsRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sessions = await repo.GetAllAsync();
            return Ok(sessions);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sessions = await repo.GetByIdAsync(id);
            return sessions == null ? NotFound() : Ok(sessions);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Sessions sessions)
        {
            var id = await repo.AddAsync(sessions);
            return Ok(new { id });
        }
        [HttpPut]
        public async Task<IActionResult> Update(Sessions sessions)
        {
            var rows = await repo.UpdateAsync(sessions);
            return rows > 0 ? Ok() : NotFound();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rows = await repo.DeleteAsync(id);
            return rows > 0 ? Ok() : NotFound();
        }
    }
}
