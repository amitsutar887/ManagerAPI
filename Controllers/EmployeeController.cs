using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MANAGERAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly AppDbContext context;
        private readonly ILogger< EmployeeController> _logger;

        public EmployeeController(AppDbContext _context, ILogger<ManagerController> logger)
        {
            this.context = _context;
            _logger = logger;
        }

        [httpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {

            try
            {
                var entity = new Employee
                {
                    EmpId = employee.EmpId,
                    EmpName = employee.EmpName,
                    Salary = employee.Salary,
                }
             _context.Employees.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex){
                return Json(new {status = 400, statusText = ex.Message});
            }
            return Json(entity);
        }
    }
}
