using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskHTTPMethods.Modals;

namespace TaskHTTPMethods.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly TaskDbContext context;

        public EmployeeController(TaskDbContext context)
        {
            this.context = context;
        }

        [HttpGet("getEmployees")]
        public IActionResult getemps()
        {
            List<Employee> employees = new List<Employee>();
            employees = context.Employees.ToList();
            return Ok(employees);
        }

        [HttpPost("addEmployee")]
        public async Task<IActionResult> AddEmp([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("enter EMployee");
            }
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut("updateEmployee")]
        public async Task<IActionResult> updateEmp([FromBody] Employee employee)
        {
            Employee employee1 = await context.Employees.FindAsync(employee.EmpId);
            if (employee1 == null)
            {
                return BadRequest("Employee not found");
            }
            employee1.EmpEmail = employee.EmpEmail;
            employee1.EmpName = employee.EmpName;
            employee1.EmpSal = employee.EmpSal;
            employee1.CategoryId = employee.CategoryId;
            await context.SaveChangesAsync();
            return Ok(employee1 + "EMployee updated");
        }

        [HttpDelete("deleteEmp")]
        public async Task<IActionResult> deleteEmp(int id)
        {
            if(id == 0 || id==null)
            {
                return BadRequest("Enter the employee id");
            }
            Employee employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                return BadRequest("not found employee");
            }
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return Ok("Employee delated");
        }

        [HttpPost("SearchEmployee")]
        public async Task<List<Employee>> searchEmp(string name)
        {
            List<Employee> employees = new List<Employee>();
            employees = await context.Employees.Where(a=>a.EmpName.Contains(name)).ToListAsync();
            return employees;
        }


    }
}
