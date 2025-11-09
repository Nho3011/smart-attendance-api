using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolmentController(IEnrolmentRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrolment= await repo.GetAllAsync();
            return Ok(enrolment);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var enrolmment= await repo.GetByIdAsync(id);
            return enrolmment==null? NotFound():Ok(enrolmment);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Enrolment enrolment)
        {
            var id=await repo.AddAsync(enrolment);
            return Ok(new { id });
        }
        [HttpPut]
        public async Task<IActionResult> Update(Enrolment enrolment)
        {
            var rows= await repo.UpdateAsync(enrolment);
            return rows>0 ? Ok() : NotFound();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rows=await repo.DeleteAsync(id);
            return rows>0 ? Ok() : NotFound();
        }
    }
}
