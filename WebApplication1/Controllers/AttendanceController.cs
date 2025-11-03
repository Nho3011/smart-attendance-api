using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController(IAttendanceRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            var Attendance=await repo.GetAllAsync();
            return Ok(Attendance);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Attendance= await repo.GetByIdAsync(id);
            return Attendance == null ? NotFound() : Ok(Attendance);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Attendance attendance)
        {
            var id=await repo.AddAsync(attendance);
            return Ok(new { id });
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, Attendance attendance)
        {
            attendance.Attendance_id = id;
            var row=await repo.UpdateAsync(attendance);
            return row >0? Ok() : NotFound();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var row=await repo.DeleteAsync(id);
            return row >0?Ok():NotFound();
        }
    }
}
