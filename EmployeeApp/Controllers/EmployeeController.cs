using EmployeeApp.Repositories.EmployeeRepo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using zModelEntities.Models.EmployeeModels;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _empRepo;

        public EmployeeController(IEmployeeRepo empRepo)
        {
            _empRepo = empRepo;
        }

        [HttpGet("GetEmployees")]
        public Task<List<Employee>> GetEmployees()
        {
            return _empRepo.GetEmployees();
        }


        [HttpGet("GetEmployee/{id}")]
        public Task<Employee> GetEmployee(int id)
        {
            return _empRepo.FindEmployee(id);
        }


        [HttpPost("AddOrEditEmployee")]
        public Task<Employee> AddOrEditEmployee(Employee employee)
        {
            return _empRepo.AddOrEdit(employee);
        }


        [HttpGet("DeleteEmployee/{id}")]
        public Task<string> DeleteEmployee(int id)
        {
            var emp = _empRepo.FindEmployee(id);
            if (emp.Result == null)
            {
                return Task.FromResult("Not Found!");
            }
            return _empRepo.DeleteEmployee(emp.Result);
        }
    }
}
