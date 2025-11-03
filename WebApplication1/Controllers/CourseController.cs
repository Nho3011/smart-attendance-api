using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController (ICourseRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var course= await repo.GetAllAsync();
            return Ok(course);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course= await repo.GetByIdAsync(id);
            return course==null ? NotFound() : Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Course course)
        {
            var id= await repo.AddAsync(course);
            return Ok(new { id });
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Course course)
        {
            course.Course_id = id;
            var rows=await repo.UpdateAsync(course);
            return rows>0?Ok():NotFound();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rows=await repo.DeleteAsync(id);    
            return rows>0 ? Ok():NotFound();
        }
    }
}
