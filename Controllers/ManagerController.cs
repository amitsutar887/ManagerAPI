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
    public class ManagerController : ControllerBase
    {

        private readonly AppDbContext context;
        private readonly ILogger<ManagerController> _logger;

        public ManagerController(AppDbContext _context, ILogger<ManagerController> logger)
        {
            this.context = _context;
            _logger = logger;
        }

        [httpPost]
        [Route("AddManager")]
        public async Task<IActionResult> AddManager(Manager manager)
        {

            try
            {
                var entity = new Manager
                {
                    ManagerId = manager.ManagerId,
                    ManagerName = manager.ManagerName,
                }
             _context.Managers.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Json(new { status = 400, statusText = ex.Message });
            }
            return Json(entity);
        }

        [httpGet]
        [Route("GetManagerById")]
        public async Task<IActionResult> GetManagerById(int Id)
        {
            try
            {
                var Emplist = _context.Employee.where(x => x.ManagerId == Id).Select(x => x.EmpId && x.EmpName && x.Salary).ToList();
            }
            catch (Exception ex)
            {
                return Json(new { status = 400, statusText = ex.Message });
            }
            return Json(Emplist);
        }

    }
}
