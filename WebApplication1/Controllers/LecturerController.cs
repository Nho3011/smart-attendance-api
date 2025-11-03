using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController(ILecturerRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lecturer = await repo.GetAllAsync();
            return Ok(lecturer);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lecturer = repo.GetByIdAsync(id);
            return lecturer == null ? NotFound() : Ok(lecturer);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Lecturer lecturer)
        {
            var id = await repo.AddAsync(lecturer);
            return Ok(new { id });
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Lecturer lecturer)
        {
            lecturer.User_id = id;
            var rows = await repo.UpdateAsync(lecturer);
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
