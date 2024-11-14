using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using secondProject.Data;
using secondProject.DTOs.EmployeeDto;
using secondProject.Model;

namespace secondProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var employees = context.Employees.ToList();
            var employeeDot = employees.Adapt<IEnumerable<GetAllEmployeeDto>>();
            return Ok(employeeDot);
        }
        [HttpPost("add")]
        public IActionResult addemployee(CreateEmployeeDto employee) { 
            var employees = employee.Adapt<Employee>();
            context.Employees.Add(employees);
            context.SaveChanges();
            return Ok(employee);    
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id) {
            var employee = context.Employees.Find(id);
            if (employee != null) { 
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return Ok();

        }
        [HttpPut("update")]
        public IActionResult update(UpdateEmployeeDto empDto, int id) { 
            var carer=context.Employees.Find(id);
            if (carer != null) {
                var employee = empDto.Adapt<Employee>();
                 carer.Name = employee.Name;
                carer.Description = employee.Description;
                carer.DepartmentId = employee.DepartmentId;
                context.SaveChanges();
            }
            return Ok();
        }
    }
}
