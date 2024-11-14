using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using secondProject.Data;
using secondProject.DTOs.EmployeeDto;
using secondProject.Model;

namespace secondProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartnebtController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DepartnebtController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var departments = context.Departments.Select(
                 dep=>new GetAllDepartmentDto
                 {
                     Id=dep.Id,
                     Name=dep.Name,
                 }
                );
            return Ok(departments);
        }
        [HttpPost("add")]
        public IActionResult addDepartments(CreateDepartmentDto departDto)
        {
           Department departments = new Department() { 
            Name = departDto.Name,
           };
            context.Departments.Add(departments);
            context.SaveChanges();
            return Ok(departDto);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var department = context.Departments.Find(id);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
            }
            return Ok();

        }
        [HttpPut("update")]
        public IActionResult update(UpdateDepartmentDto depDto, int id)
        {
            var carer = context.Departments.Find(id);
            if (carer != null)
            {
                Department department = new Department() { 
                 Name=depDto.Name,
                };
            }
            return Ok(depDto);
        }
    }
}
