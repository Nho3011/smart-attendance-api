using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUsersRepository repo) : ControllerBase 
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await repo.GetAllAsync();
            return Ok(users);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var users = await repo.GetByIdAsync(id);
            return users == null ? NotFound() : Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Users users)
        {
            var id = await repo.AddAsync(users);
            return Ok(new { id });
        }
        [HttpPut]
        public async Task<IActionResult> Update(Users users)
        {
            var rows = await repo.UpdateAsync(users);
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
